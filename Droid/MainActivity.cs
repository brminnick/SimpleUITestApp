﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace SimpleUITestApp.Droid
{
	[Activity (Theme = "@android:style/Theme.Material.Light", Label = "SimpleUITestApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			global::Xamarin.Forms.Forms.ViewInitialized += (object sender, Xamarin.Forms.ViewInitializedEventArgs e) => {
				if (!string.IsNullOrWhiteSpace(e.View.AutomationId)) {
					e.NativeView.ContentDescription = e.View.AutomationId;
				}
			};

			LoadApplication (new App ());
		}
	}
}

