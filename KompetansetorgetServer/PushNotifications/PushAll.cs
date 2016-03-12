using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace KompetansetorgetServer.PushNotifications
{
    public class PushAll
    {
        // API_KEY should be stored in db
        public const string API_KEY = "AIzaSyDIbpRonx7yh3NKBAr4rAzmfmIFeEWRTfE";

        //public const string MESSAGE = "Hello, Xamarin!";

        public void SendMessageToAllAndroid(string message)
        {
            var jGcmData = new JObject();
            var jData = new JObject();

            jData.Add("message", message);
            jGcmData.Add("to", "/topics/global");
            jGcmData.Add("data", jData);

            var url = new Uri("https://gcm-http.googleapis.com/gcm/send");
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.TryAddWithoutValidation(
                        "Authorization", "key=" + API_KEY);

                    Task.WaitAll(client.PostAsync(url,
                        new StringContent(jGcmData.ToString(), Encoding.Default, "application/json"))
                        .ContinueWith(response =>
                        {
                            Console.WriteLine(response);
                            Console.WriteLine("Message sent: check the client device notification tray.");
                        }));
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Unable to send GCM message:");
                Debug.WriteLine(e.StackTrace);
            }
        }
    }
}