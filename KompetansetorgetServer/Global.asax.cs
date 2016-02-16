
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

			/*
			pushBroker.OnNotificationSent += NotificationSent;
			pushBroker.OnChannelException += ChannelException;
			pushBroker.OnServiceException += ServiceException;
			pushBroker.OnNotificationFailed += NotificationFailed;
			pushBroker.OnDeviceSubscriptionExpired += DeviceSubscriptionExpired;
			pushBroker.OnDeviceSubscriptionChanged += DeviceSubscriptionChanged;
			pushBroker.OnChannelCreated += ChannelCreated;
			pushBroker.OnChannelDestroyed += ChannelDestroyed;
			*/

			HttpContext.Current.Application["MyPushBroker"] = pushBroker;

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
