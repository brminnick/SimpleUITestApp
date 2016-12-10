using System;

using Android.App;
using Android.Runtime;
using SimpleUITestApp.Shared;
using Xamarin;

namespace SimpleUITestApp.Droid
{
	//You can specify additional application information in this attribute
	[Application]

	public class SimpleUITest_Application : Application
	{
		public SimpleUITest_Application(IntPtr handle, JniHandleOwnership transer)
		  : base(handle, transer)
		{
		}

		public override void OnCreate()
		{
			base.OnCreate();

            AnalyticsHelpers.Start(AnalyticsConstants.MOBILE_CENTER_DROID_API_KEY);
		}
	}
}