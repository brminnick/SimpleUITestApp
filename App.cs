using System;

using MyLoginUI;

using Xamarin.Forms;

using MyLoginUI.Pages;

namespace SimpleUITestApp
{

	public class App : Application
	{
		public static bool XTCAgent;
		public static bool IsLoggedIn;
		public static string UserName;

		public static NavigationPage Navigation;

		public App()
		{
			var page = new LoginPage { LogoFileImageSource = "xamarin_logo" };

			NavigationPage.SetHasNavigationBar(page, false);
			Navigation = new NavigationPage(page)
			{
				BarBackgroundColor = Color.FromHex("#3498db"),
				BarTextColor = Color.White,
			};
			MainPage = Navigation;
		}

		protected override void OnStart()
		{
			int majorVersion, minorVersion;
			if(Device.OS == TargetPlatform.iOS)
			{
				majorVersion = 9;
				minorVersion = 0;
			}
			else if(Device.OS == TargetPlatform.Android)
			{
				majorVersion = 23;
				minorVersion = 0;
			}
			if (DependencyService.Get<IEnvironment>().IsOperatingSystemSupported(9, 0))
			{
				var listViewPageLink = Extensions.CreateAppLink("List View Page", "Open the List View Page", DeepLinkingIdConstants.ListViewPageId);
				AppLinks.RegisterLink(listViewPageLink);
			}
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		protected override void OnAppLinkRequestReceived(Uri uri)
		{
			if (uri.ToString().Equals($"{Extensions.BaseUrl}{DeepLinkingIdConstants.ListViewPageId}"))
			{
				//Navigate to List View Page
				Device.BeginInvokeOnMainThread(async () =>
				{
					await Navigation.PopToRootAsync();
					await Navigation.PushAsync(new ListViewPage());
				});
			}

			base.OnAppLinkRequestReceived(uri);
		}


		public void OpenListViewPageUsingDeepLinking()
		{
			OnAppLinkRequestReceived(new Uri($"{Extensions.BaseUrl}ListViewPage"));
		}

		public void OpenListViewPageUsingNavigation()
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				await Navigation.PopToRootAsync();
				await Navigation.PushAsync(new ListViewPage());
			});
		}
	}
}


