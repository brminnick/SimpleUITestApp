using UIKit;

using Microsoft.Azure.Mobile;

using SimpleUITestApp.Shared;

namespace SimpleUITestApp.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main(string[] args)
		{
			AnalyticsHelpers.Start(AnalyticsConstants.MOBILE_CENTER_iOS_API_KEY);

			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main(args, null, "AppDelegate");
		}
	}
}

