using Xamarin.Forms;

using SimpleUITestApp.Droid;

using System;

using Android.OS;

[assembly: Dependency(typeof(Environment_Android))]
namespace SimpleUITestApp.Droid
{
	public class Environment_Android : IEnvironment
	{
		public string GetOperatingSystemVersion()
		{
			return Build.VERSION.SdkInt.ToString();
		}

		public bool IsOperatingSystemSupported(int majorVersion, int minorVersion)
		{
			try
			{
				int sdkInt;
				int.TryParse(Build.VERSION.SdkInt.ToString(), out sdkInt);

				return sdkInt >= majorVersion;

			}
			catch (Exception e)
			{
				return false;
			}
		}
	}
}

