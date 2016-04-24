using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using KompetansetorgetServer.PushNotifications;
using PushSharp;
using PushSharp.Android;
using PushSharp.Core;

namespace KompetansetorgetServer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Initiate_PushBroker();
        }
    }
}

/*
protected void Application_End()
        {
            //pushBroker.StopAllServices();
        }
        */
        /*
        private static PushBroker pushBroker;
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
		}

		static void DeviceSubscriptionChanged(object sender, string oldSubscriptionId, string newSubscriptionId, INotification notification)
		{
            //Currently this event will only ever happen for Android GCM
            Debug.WriteLine("Device Registration Changed:  Old-> " + oldSubscriptionId + "  New-> " + newSubscriptionId + " -> " + notification);
		}

		static void NotificationSent(object sender, INotification notification)
		{
            Debug.WriteLine("Sent: " + sender + " -> " + notification);
		}

		static void NotificationFailed(object sender, INotification notification, Exception notificationFailureException)
		{
            Debug.WriteLine("Failure: " + sender + " -> " + notificationFailureException.Message + " -> " + notification);
		}

		static void ChannelException(object sender, IPushChannel channel, Exception exception)
		{
            Debug.WriteLine("Channel Exception: " + sender + " -> " + exception);
		}

		static void ServiceException(object sender, Exception exception)
		{
            Debug.WriteLine("Service Exception: " + sender + " -> " + exception);
		}

		static void DeviceSubscriptionExpired(object sender, string expiredDeviceSubscriptionId, DateTime timestamp, INotification notification)
		{
            Debug.WriteLine("Device Subscription Expired: " + sender + " -> " + expiredDeviceSubscriptionId);
		}

		static void ChannelDestroyed(object sender)
		{
            Debug.WriteLine("Channel Destroyed for: " + sender);
		}

		static void ChannelCreated(object sender, IPushChannel pushChannel)
		{
            Debug.WriteLine("Channel created for: " + sender);
		}
        */
