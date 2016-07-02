using System;
using System.Threading.Tasks;

using Xamarin.Forms;

using Xamarin;

namespace SimpleUITestApp
{
	public class FirstPage : BasePage
	{
		Label textLabel = new Label();
		Entry textEntry = new Entry();
		Button goButton = new Button();
		Button listViewButton = new Button();
		ActivityIndicator activityIndicator = new ActivityIndicator();

		public FirstPage()
		{
			Title = "First Page";

			string entryTextPaceHolder = "Enter text and click 'Go'";

			goButton.Text = "Go";
			goButton.AutomationId = "MyGoButton"; // This provides an ID that can be referenced in UITests
			goButton.Style = StyleConstants.BorderedButton; //The formats the BackgroundColor, Border Radius and Height Request Property

			textEntry.Placeholder = entryTextPaceHolder;
			textEntry.AutomationId = "MyEntry"; // This provides an ID that can be referenced in UITests
			textEntry.Style = StyleConstants.UnderlinedEntry;

			textLabel.Text = "Your text will appear here";
			textLabel.AutomationId = "MyLabel"; // This provides an ID that can be referenced in UITests
			textLabel.HorizontalOptions = LayoutOptions.Center;
			textLabel.Style = StyleConstants.WhiteTextLabel;

			goButton.Clicked += OnButtonClick;

			listViewButton.Text = "Go to List View Page";
			listViewButton.AutomationId = "MyListViewButton"; // This provides an ID that can be referenced in UITests
			listViewButton.Style = StyleConstants.BorderedButton; //The formats the BackgroundColor, Border Radius and Height Request Property

			activityIndicator.AutomationId = "MyActivityIndicator";

			listViewButton.Clicked += (sender, e) =>
			{
				Device.BeginInvokeOnMainThread(() =>
				{
					Navigation.PushAsync(new ListViewPage());
				});
			};


			var stackLayout = new StackLayout
			{
				Children = {
					textEntry,
					goButton,
					activityIndicator,
					textLabel,
				},
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand

			};

			var relativeLayout = new RelativeLayout();
			relativeLayout.Children.Add(stackLayout,
				Constraint.RelativeToParent((parent) =>
				{
					return parent.X;
				}),
				Constraint.RelativeToParent((parent) =>
				{
					return parent.Y;
				}),
				Constraint.RelativeToParent((parent) =>
				{
					return parent.Width - 20;
				}),
				Constraint.RelativeToParent((parent) =>
				{
					return parent.Height / 2;
				})
			);

			relativeLayout.Children.Add(listViewButton,
				Constraint.RelativeToParent((parent) =>
				{
					return parent.X;
				}),
				Constraint.Constant(250),
				Constraint.RelativeToParent((parent) =>
				{
					return parent.Width - 20;
				})
			);

			Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
			Content = relativeLayout;
		}

		public async void OnButtonClick(object sender, EventArgs e)
		{
			string entryText = textEntry.Text;
			Insights.Track(Insights_Constants.GO_BUTTON_TAPPED, Insights_Constants.TEXT_ENTERED, entryText);

			Device.BeginInvokeOnMainThread(() =>
			{
				//Hide the keyboard
				textEntry.Unfocus();

				//Show the activity indicator and hide the Go Button
				activityIndicator.IsRunning = true;
				activityIndicator.IsVisible = true;
				goButton.IsVisible = false;
				goButton.IsEnabled = false;
			});
			//Perform a task for 2000 miliseconds
			var timer = Insights.TrackTime(Insights_Constants.ACTIVITY_INDICATOR_ONSCREEN);
			timer.Start();
			await Task.Delay(2000);
			timer.Stop();

			Device.BeginInvokeOnMainThread(() =>
			{
				//Hide the activity indicator now that task has completed
				activityIndicator.IsRunning = false;
				activityIndicator.IsVisible = false;
				goButton.IsVisible = true;
				goButton.IsEnabled = true;

				//display the 
				textLabel.Text = entryText;
			});
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			Insights.Track(Insights_Constants.FIRST_PAGE_ON_APPEARING);
		}
	}
}


