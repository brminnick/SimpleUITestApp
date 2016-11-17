using System;

using Android.OS;

using SimpleUITestApp.Droid;

using Xamarin.Forms;

[assembly: Dependency(typeof(Environment_Android))]
namespace SimpleUITestApp.Droid
{
	public class Environment_Android : IEnvironment
	{
		public string GetOperatingSystemVersion()
		{
			return Build.VERSION.Release;
		}

		public bool IsOperatingSystemSupported(int majorVersion, int minorVersion)
		{
			try
			{
				double sdkInt;
				double.TryParse(Build.VERSION.Release, out sdkInt);

				return sdkInt >= (majorVersion + minorVersion * .1);

			}
			catch (Exception e)
			{
				AnalyticsHelpers.LogWarning("Operating System Check Failed", e.Message, e);
				return false;
			}
		}
	}
}

