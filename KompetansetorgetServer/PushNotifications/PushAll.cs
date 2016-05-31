using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KompetansetorgetServer.Models;
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
            string message1 = "Ny stilling registert";
            string uuid = "c32c5b2b-4e3a-4e07-bc39-1b5c3ff82aab";
            string type = "project";

            var jGcmData = new JObject();
            var jData = new JObject();

            jData.Add("message", message);
            jData.Add("uuid", uuid);
            jData.Add("type", type);
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


        public void SendAdvertToAllAndroid(string type)
        {
            KompetansetorgetServerContext db = new KompetansetorgetServerContext();

            Random rnd = new Random();
            string uuid;
            string message;
            if (type == "project")
            {
                List<Project> projects = db.projects.ToList();
                int index = rnd.Next(0, projects.Count); // creates a number between 0 and Count
                uuid = projects[index].uuid;
                message = "Nytt oppgaveforslag registert!";
            }

            else
            {
                List<Job> jobs = db.jobs.ToList();
                int index = rnd.Next(0, jobs.Count); // creates a number between 0 and Count
                uuid = jobs[index].uuid;
                message = "Ny jobbstilling registert!";
            }

            var jGcmData = new JObject();
            var jData = new JObject();

            jData.Add("message", message);
            jData.Add("uuid", uuid);
            jData.Add("type", type);
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