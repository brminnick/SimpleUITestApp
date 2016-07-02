using System;

using Xamarin.Forms;

namespace SimpleUITestApp
{
	public class NewUserSignUpPage : ContentPage
	{
		Button saveUsernameButton, cancelButton;
		Entry usernameEntry, passwordEntry;
		StackLayout layout;

		public NewUserSignUpPage()
		{
			BackgroundColor = Color.FromHex("#2980b9");
			ConstructUI();
			AddChildrenToParentLayout();
		}


		public void ConstructUI()
		{
			layout = new StackLayout
			{
				Padding = new Thickness(20, 50, 20, 20),
				VerticalOptions = LayoutOptions.FillAndExpand,
			};

			usernameEntry = new Entry
			{
				Style = StyleConstants.UnderlinedEntry,
				AutomationId = "newUsernameEntry",
				Placeholder = "Username",
				HorizontalOptions = LayoutOptions.Fill,
				HorizontalTextAlignment = TextAlignment.End
			};

			passwordEntry = new Entry
			{
				Style = StyleConstants.UnderlinedEntry,
				AutomationId = "newPasswordEntry",
				Placeholder = "Password",
				IsPassword = true,
				HorizontalOptions = LayoutOptions.Fill,
				HorizontalTextAlignment = TextAlignment.End,
				VerticalOptions = LayoutOptions.Fill
			};

			saveUsernameButton = new Button
			{
				Style=StyleConstants.BorderedButton,
				AutomationId = "saveUsernameButton",
				Text = "Save Username",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.EndAndExpand
			};
			cancelButton = new Button
			{
				Style = StyleConstants.BorderedButton,
				AutomationId = "cancelButton",
				Text = "Cancel",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.End
			};

			saveUsernameButton.Clicked += async (object sender, EventArgs e) =>
			{
				var success = await DependencyService.Get<ILogin>().SetPasswordForUsername(usernameEntry.Text, passwordEntry.Text);
				if (success)
					Navigation.PopModalAsync();
				else
					DisplayAlert("Error", "You must enter a username and a password", "Okay");
			};

			cancelButton.Clicked += (object sender, EventArgs e) =>
			{
				Navigation.PopModalAsync();
			};
		}

		public void AddChildrenToParentLayout()
		{
			layout.Children.Add(
				new Label
				{
					Style = StyleConstants.WhiteTextLabel,
					Text = "Please enter username",
					HorizontalOptions = LayoutOptions.Start
				}
			);
			layout.Children.Add(usernameEntry);
			layout.Children.Add(
				new Label
				{
					Style = StyleConstants.WhiteTextLabel,
					Text = "Please enter password",
					HorizontalOptions = LayoutOptions.Start
				}
			);
			layout.Children.Add(passwordEntry);
			layout.Children.Add(saveUsernameButton);
			layout.Children.Add(cancelButton);

			Content = new ScrollView{
				Content = layout
			};
		}

		protected override void LayoutChildren(double x, double y, double width, double height)
		{
			cancelButton.WidthRequest = width - 40;
			saveUsernameButton.WidthRequest = width - 40;

			base.LayoutChildren(x, y, width, height);
		}
	}
}