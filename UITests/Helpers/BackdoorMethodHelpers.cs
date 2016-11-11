﻿using Xamarin.UITest;
using Xamarin.UITest.iOS;

namespace SimpleUITestApp.UITests
{
	public static class BackdoorMethodHelpers
	{
		internal static void CleariOSKeyChain(IApp app)
		{
			if(app is iOSApp)
				app.Invoke("clearKeyChain:", "");
		}

		internal static void SetiOSXTCAgent(IApp app)
		{
			if(app is iOSApp)
				app.Invoke("xtcAgent:", "");
		}

		internal static void BypassLoginScreen(IApp app)
		{
			if (app is iOSApp)
				app.Invoke("bypassLoginScreen:", "");
			else
				app.Invoke("BypassLoginScreen");

			app.Screenshot("Backdoor Bypass Login Screen");
		}

		internal static void OpenListViewPage(IApp app)
		{
			if (app is iOSApp)
				app.Invoke("openListViewPage:", "");
			else
				app.Invoke("OpenListViewPage");

			app.Screenshot("Backdoor to List View Page");
		}
	}
}
