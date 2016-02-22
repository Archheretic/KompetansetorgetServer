using System;
using PushSharp;
using PushSharp.Android;
using PushSharp.Apple;

using System.IO;
using System.Web;


namespace KompetansetorgetServer
{
	public class Push
	{
		private PushBroker pushBroker = HttpContext.Current.Application["MyPushBroker"] as PushBroker;

		public Push ()
		{

			string myAuthToken = "cvi1LZzRdZ4:APA91bERsfF7kNNMmXV_4qhcwEg7_D5tQCIJhua-QbrGnyIBIsF0K7ovqVcZi9kWRRgheERodLCwbNDwXtNmZWXimZzDbwAPboR3CKcl4OkT6BeHMSSvnpgA9yvgknbqOhEFQjH4eO6Z";


			//Registering the GCM Service and sending an Android Notification
			pushBroker.RegisterGcmService(new GcmPushChannelSettings("AIzaSyDIbpRonx7yh3NKBAr4rAzmfmIFeEWRTfE"));

			//Fluent construction of an Android GCM Notification
			//IMPORTANT: For Android you MUST use your own RegistrationId here that gets generated within your Android app itself!
			pushBroker.QueueNotification(new GcmNotification().ForDeviceRegistrationId(myAuthToken)
				//.WithJson("{\"alert\":\"Hello World!\",\"badge\":7,\"sound\":\"sound.caf\"}"));
				.WithJson(@"{""alert"":""Hello World!"",""badge"":7,""sound"":""sound.caf""}"));


			/*
			//Registering the Apple Service and sending an iOS Notification
			var appleCert = File.ReadAllBytes (
				Path.Combine (AppDomain.CurrentDomain.BaseDirectory, 
					"ApnsSandboxCert.p12"));

			var appleSettings = new ApplePushChannelSettings (appleCert,  
				"password");
			pushBroker.RegisterAppleService(appleSettings);

			var appleNotification = new AppleNotification ()
				.ForDeviceToken ("Device Token HERE")
				.WithAlert ("Hello world!")
				.WithBadge (3)
				.WithSound("sound.caf");

			pushBroker.QueueNotification(appleNotification);

			*/

		}
	}
}