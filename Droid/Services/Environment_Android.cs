using Xamarin.Forms;

using SimpleUITestApp.Droid;

using Android.OS;

[assembly: Dependency(typeof(Environment_Android))]
namespace SimpleUITestApp.Droid
{
	public class Environment_Android : IEnvironment
	{
		public string GetOperatingSystemVersion()
		{
			return Build.VERSION.Sdk;
		}

		public bool IsOperatingSystemSupported(int majorVersion, int minorVersion)
		{
			var buildSDKInt = Build.VERSION.SdkInt;
			var buildSDK = Build.VERSION.Sdk;
			return false;
		}
	}
}

