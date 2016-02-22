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

			string myAuthToken = "dRoHtQTtEdo:APA91bH0KuEL90_iSX6gFXJy2kOPcmDbX_3Ts1-Can3tBIpyWGdipZefLxZayb2zBz93o_8uGMpOOSXxnsSoqO2YAHl9pfh2BYIqm6mbIW71AhXpeQgycbVWj3QnFt9TTgb-2sIKH-qR";


			//Registering the GCM Service and sending an Android Notification
			pushBroker.RegisterGcmService(new GcmPushChannelSettings("AIzaSyDIbpRonx7yh3NKBAr4rAzmfmIFeEWRTfE"));

			//Fluent construction of an Android GCM Notification
			//IMPORTANT: For Android you MUST use your own RegistrationId here that gets generated within your Android app itself!
			pushBroker.QueueNotification(new GcmNotification().ForDeviceRegistrationId(myAuthToken)
				//.WithJson("{\"alert\":\"Hello World!\",\"badge\":7,\"sound\":\"sound.caf\"}"));
				.WithJson(@"{""message"":""Hello World!"",""badge"":7,""sound"":""sound.caf""}"));


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