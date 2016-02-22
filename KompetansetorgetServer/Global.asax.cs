
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using PushSharp;
using PushSharp.Core;


namespace KompetansetorgetServer
{
	public class MvcApplication : System.Web.HttpApplication
	{
		private static PushBroker pushBroker;

		public static void RegisterRoutes (RouteCollection routes)
		{
			routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");

			routes.MapRoute (
				"Default",
				"{controller}/{action}/{id}",
				new { controller = "Home", action = "Index", id = "" }
			);

		}

		public static void RegisterGlobalFilters (GlobalFilterCollection filters)
		{
			filters.Add (new HandleErrorAttribute ());
		}

		protected void Application_Start ()
		{
			// The line under is taken from a ASP.NET 4.52 MVC Web Api application
			// GlobalConfiguration i not recognized.
			GlobalConfiguration.Configure(WebApiConfig.Register);
			//WebApiConfig.Register(GlobalConfiguration.Configuration);

			AreaRegistration.RegisterAllAreas ();
			RegisterGlobalFilters (GlobalFilters.Filters);
			RegisterRoutes (RouteTable.Routes);
			Initiate_PushBroker ();
		}

		protected void Application_End()
		{
			pushBroker.StopAllServices();
		}


		void Initiate_PushBroker()
		{
			// 
			pushBroker = new PushBroker();


			pushBroker.OnNotificationSent += NotificationSent;
			pushBroker.OnChannelException += ChannelException;
			pushBroker.OnServiceException += ServiceException;
			pushBroker.OnNotificationFailed += NotificationFailed;
			pushBroker.OnDeviceSubscriptionExpired += DeviceSubscriptionExpired;
			pushBroker.OnDeviceSubscriptionChanged += DeviceSubscriptionChanged;
			pushBroker.OnChannelCreated += ChannelCreated;
			pushBroker.OnChannelDestroyed += ChannelDestroyed;


			HttpContext.Current.Application["MyPushBroker"] = pushBroker;
			Push p = new Push ();
		}

		static void DeviceSubscriptionChanged(object sender, string oldSubscriptionId, string newSubscriptionId, INotification notification)
		{
			//Currently this event will only ever happen for Android GCM
			Console.WriteLine("Device Registration Changed:  Old-> " + oldSubscriptionId + "  New-> " + newSubscriptionId + " -> " + notification);
		}

		static void NotificationSent(object sender, INotification notification)
		{
			Console.WriteLine("Sent: " + sender + " -> " + notification);
		}

		static void NotificationFailed(object sender, INotification notification, Exception notificationFailureException)
		{
			Console.WriteLine("Failure: " + sender + " -> " + notificationFailureException.Message + " -> " + notification);
		}

		static void ChannelException(object sender, IPushChannel channel, Exception exception)
		{
			Console.WriteLine("Channel Exception: " + sender + " -> " + exception);
		}

		static void ServiceException(object sender, Exception exception)
		{
			Console.WriteLine("Service Exception: " + sender + " -> " + exception);
		}

		static void DeviceSubscriptionExpired(object sender, string expiredDeviceSubscriptionId, DateTime timestamp, INotification notification)
		{
			Console.WriteLine("Device Subscription Expired: " + sender + " -> " + expiredDeviceSubscriptionId);
		}

		static void ChannelDestroyed(object sender)
		{
			Console.WriteLine("Channel Destroyed for: " + sender);
		}

		static void ChannelCreated(object sender, IPushChannel pushChannel)
		{
			Console.WriteLine("Channel Created for: " + sender);
		}


	}

	// The line under is taken from a ASP.NET 4.52 MVC Web Api application
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			); 
		}
	}



}
