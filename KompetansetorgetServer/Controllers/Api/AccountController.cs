using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json.Linq;
using KompetansetorgetServer.Models;
using KompetansetorgetServer.Results;
using Microsoft.Owin.Security.OAuth;

namespace KompetansetorgetServer.Controllers.Api
{ 
    [RoutePrefix("api/v1/Account")]
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;

        public AccountController()
        {
            _repo = new AuthRepository();
        }  

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        /// <summary>
        /// Registers External Users (like Google users) to the local userbase.
        /// </summary>
        /// <param name="model">
        /// In json format:
        /// {  
        ///     "UserName":"olanordmann@gmail.com",
        ///     "provider":"Google",
        ///     "ExternalAccessToken":"ya29..zQISFKLueNjUErUtImpiel94ADcZNlGd8gOBYVDJ3HPh2HEB-MqNL238z6w29d45oC3Q"
        /// }
        /// </param>
        /// <returns>HTTP status code</returns>
        /// POST api/v1/Account/RegisterExternal
        [AllowAnonymous]
        [Route("RegisterExternal")]
        public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var verifiedAccessToken = await VerifyExternalAccessToken(model.Provider, model.ExternalAccessToken);
            if (verifiedAccessToken == null)
            {
                return BadRequest("Invalid Provider or External Access Token");
            }
            IdentityUser user = null;

            user = await _repo.FindAsync(new UserLoginInfo(model.Provider, verifiedAccessToken.user_id));

            bool hasRegistered = user != null;

            if (hasRegistered)
            {
                return BadRequest("External user is already registered");
            }

            user = new IdentityUser() { UserName = model.UserName };

            IdentityResult result = await _repo.CreateAsync(user);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            var info = new ExternalLoginInfo()
            {
                DefaultUserName = model.UserName,
                Login = new UserLoginInfo(model.Provider, verifiedAccessToken.user_id)
            };

            result = await _repo.AddLoginAsync(user.Id, info.Login);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            //generate access token response
            var accessTokenResponse = GenerateLocalAccessTokenResponse(model.UserName);

            return Ok(accessTokenResponse);
        }

        /// <summary>
        /// Returns a local access token that can be used to reach endpoints that require authorization.
        /// </summary>
        /// <param name="provider">e.g: Google or Facebook</param>
        /// <param name="externalAccessToken">"ya29..zQISFKLueNjUErUtImpiel94ADcZNlGd8gOBYVDJ3HPh2HEB-MqNL238z6w29d45oC3Q"</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("ObtainLocalAccessToken")]
        public async Task<IHttpActionResult> ObtainLocalAccessToken(string provider, string externalAccessToken)
        {
            if (string.IsNullOrWhiteSpace(provider) || string.IsNullOrWhiteSpace(externalAccessToken))
            {
                return BadRequest("Provider or external access token is not sent");
            }

            var verifiedAccessToken = await VerifyExternalAccessToken(provider, externalAccessToken);
            if (verifiedAccessToken == null)
            {
                return BadRequest("Invalid Provider or External Access Token");
            }

            IdentityUser user = await _repo.FindAsync(new UserLoginInfo(provider, verifiedAccessToken.user_id));

            bool hasRegistered = user != null;

            if (!hasRegistered)
            {
                // Uncomment the return in the line under to disable automatic registering of new users that ask for access tokens.
                //return BadRequest("External user is not registered");
                return await CreateNewUserFromExternalAccesToken(provider, verifiedAccessToken, externalAccessToken);
            }

            //generate access token response
            var accessTokenResponse = GenerateLocalAccessTokenResponse(user.UserName);
            return Ok(accessTokenResponse);
        }

        /// <summary>
        /// Verifies with the provider that the token is indeed valid and contains the correct client id 
        /// (not a login token for another application).
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        private async Task<ParsedExternalAccessToken> VerifyExternalAccessToken(string provider, string accessToken)
        {
            ParsedExternalAccessToken parsedToken = null;

            var verifyTokenEndPoint = "";

            if (provider == "Facebook")
            {
                //You can get it from here: https://developers.facebook.com/tools/accesstoken/
                //More about debug_tokn here: http://stackoverflow.com/questions/16641083/how-does-one-get-the-app-access-token-for-debug-token-inspection-on-facebook

                var appToken = "xxxxx";
                verifyTokenEndPoint = string.Format("https://graph.facebook.com/debug_token?input_token={0}&access_token={1}", accessToken, appToken);
            }
            else if (provider == "Google")
            {
                verifyTokenEndPoint = string.Format("https://www.googleapis.com/oauth2/v1/tokeninfo?access_token={0}", accessToken);
            }
            else
            {
                return null;
            }

            var client = new HttpClient();
            var uri = new Uri(verifyTokenEndPoint);
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                dynamic jObj = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                parsedToken = new ParsedExternalAccessToken();

                if (provider == "Facebook")
                {
                    parsedToken.user_id = jObj["data"]["user_id"];
                    parsedToken.app_id = jObj["data"]["app_id"];

                    if (!string.Equals(Startup.facebookAuthOptions.AppId, parsedToken.app_id, StringComparison.OrdinalIgnoreCase))
                    {
                        return null;
                    }
                }
                else if (provider == "Google")
                {
                    parsedToken.user_id = jObj["user_id"];
                    parsedToken.app_id = jObj["audience"];
                    // The email attribute might be null unless correct scope is given at the clients Google login implementation.
                    parsedToken.email = jObj["email"];

                    if (
                        !string.Equals(Startup.googleAuthOptions.ClientId, parsedToken.app_id,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        return null;
                    }
                }
            }
            return parsedToken;
        }

        /// <summary>
        /// Generates a local access token for the spesific user.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private JObject GenerateLocalAccessTokenResponse(string userName)
        {

            var tokenExpiration = TimeSpan.FromDays(1);

            ClaimsIdentity identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Name, userName));
            identity.AddClaim(new Claim("role", "user"));

            var props = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.Add(tokenExpiration),
            };

            var ticket = new AuthenticationTicket(identity, props);

            var accessToken = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);
            JObject tokenResponse = new JObject(
                            new JProperty("userName", userName),
                            new JProperty("access_token", accessToken),
                            new JProperty("token_type", "bearer"),
                            new JProperty("expires_in", tokenExpiration.TotalSeconds.ToString()),
                            new JProperty(".issued", ticket.Properties.IssuedUtc.ToString()),
                            new JProperty(".expires", ticket.Properties.ExpiresUtc.ToString())
            );
            return tokenResponse;
        }

        /// <summary>
        /// Creates a new user based on a external access token.
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="verifiedAccessToken"></param>
        /// <param name="externalAccessToken"></param>
        /// <returns></returns>
        private async Task<IHttpActionResult> CreateNewUserFromExternalAccesToken(string provider,
            ParsedExternalAccessToken verifiedAccessToken, string externalAccessToken)
        {
            RegisterExternalBindingModel model = new RegisterExternalBindingModel()
            {
                UserName = verifiedAccessToken.email, // this is null
                Provider = provider,
                ExternalAccessToken = externalAccessToken
            };
            Student student = new Student();
            student.username = verifiedAccessToken.email;
            student.email = verifiedAccessToken.email;
            KompetansetorgetServerContext db = new KompetansetorgetServerContext();
            db.students.Add(student);
            db.SaveChanges();
            return await RegisterExternal(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        /* This code is not needed for this projects purpose, but is usefull if I had implemented external login in the browser.
// GET api/v1/Account/ExternalLogin
[OverrideAuthentication]
[HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
[AllowAnonymous]
[Route("ExternalLogin", Name = "ExternalLogin")]
public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
{
    string redirectUri = string.Empty;

    if (error != null)
    {
        return BadRequest(Uri.EscapeDataString(error));
    }

    if (!User.Identity.IsAuthenticated)
    {
        return new ChallengeResult(provider, this);
    }

    var redirectUriValidationResult = ValidateClientAndRedirectUri(this.Request, ref redirectUri);

    if (!string.IsNullOrWhiteSpace(redirectUriValidationResult))
    {
        return BadRequest(redirectUriValidationResult);
    }

    ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

    if (externalLogin == null)
    {
        return InternalServerError();
    }

    if (externalLogin.LoginProvider != provider)
    {
        Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        return new ChallengeResult(provider, this);
    }

    IdentityUser user = await _repo.FindAsync(new UserLoginInfo(externalLogin.LoginProvider, externalLogin.ProviderKey));

    bool hasRegistered = user != null;

    redirectUri = string.Format("{0}#external_access_token={1}&provider={2}&haslocalaccount={3}&external_user_name={4}",
                                    redirectUri,
                                    externalLogin.ExternalAccessToken,
                                    externalLogin.LoginProvider,
                                    hasRegistered.ToString(),
                                    externalLogin.UserName);

    return Redirect(redirectUri);

}

private string ValidateClientAndRedirectUri(HttpRequestMessage request, ref string redirectUriOutput)
{

    Uri redirectUri;

    var redirectUriString = GetQueryString(Request, "redirect_uri");

    if (string.IsNullOrWhiteSpace(redirectUriString))
    {
        return "redirect_uri is required";
    }

    bool validUri = Uri.TryCreate(redirectUriString, UriKind.Absolute, out redirectUri);

    if (!validUri)
    {
        return "redirect_uri is invalid";
    }

    var clientId = GetQueryString(Request, "client_id");

    if (string.IsNullOrWhiteSpace(clientId))
    {
        return "client_Id is required";
    }

    var client = _repo.FindClient(clientId);

    if (client == null)
    {
        return string.Format("Client_id '{0}' is not registered in the system.", clientId);
    }

    if (!string.Equals(client.AllowedOrigin, redirectUri.GetLeftPart(UriPartial.Authority), StringComparison.OrdinalIgnoreCase))
    {
        return string.Format("The given URL is not allowed by Client_id '{0}' configuration.", clientId);
    }

    redirectUriOutput = redirectUri.AbsoluteUri;

    return string.Empty;

}

private string GetQueryString(HttpRequestMessage request, string key)
{
    var queryStrings = request.GetQueryNameValuePairs();

    if (queryStrings == null) return null;

    var match = queryStrings.FirstOrDefault(keyValue => string.Compare(keyValue.Key, key, true) == 0);

    if (string.IsNullOrEmpty(match.Value)) return null;

    return match.Value;
}

private class ExternalLoginData
{
    public string LoginProvider { get; set; }
    public string ProviderKey { get; set; }
    public string UserName { get; set; }
    public string ExternalAccessToken { get; set; }

    public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
    {
        if (identity == null)
        {
            return null;
        }

        Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

        if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer) || String.IsNullOrEmpty(providerKeyClaim.Value))
        {
            return null;
        }

        if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
        {
            return null;
        }

        return new ExternalLoginData
        {
            LoginProvider = providerKeyClaim.Issuer,
            ProviderKey = providerKeyClaim.Value,
            UserName = identity.FindFirstValue(ClaimTypes.Name),
            ExternalAccessToken = identity.FindFirstValue("ExternalAccessToken"),
        };
    }
}
*/

        /*
// POST api/Account/Register
/// <summary>
/// Used for registering local accounts
/// </summary>
/// <param name="userModel"></param>
/// <returns></returns>
[AllowAnonymous]
[Route("Register")]
public async Task<IHttpActionResult> Register(UserModel userModel)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    IdentityResult result = await _repo.RegisterUser(userModel);

    IHttpActionResult errorResult = GetErrorResult(result);

    if (errorResult != null)
    {
        return errorResult;
    }

    return Ok();
}
*/
    }
}
