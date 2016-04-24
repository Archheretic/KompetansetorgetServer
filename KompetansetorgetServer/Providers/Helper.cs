using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace KompetansetorgetServer.Providers
{
    /// <summary>
    /// Helper class for encrypting things that should not be unencrypted in the database,
    /// like password, client secrets etc...
    /// Should considering implementing salt, if used in a real application.
    /// </summary>
    public class Helper
    {
        public static string GetHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);

            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }
    }
}