using NUnit.Framework;

using Xamarin.UITest;

namespace SimpleUITestApp.UITests
{
	public class Tests : AbstractSetup
	{
		public Tests(Platform platform) : base(platform)
		{
			this.platform = platform;
		}

		[Test]
		public void EnterText()
		{
			FirstPage.EnterText("Hello World");
			FirstPage.ClickGo();
			FirstPage.WaitForNoActivityIndicator();
		}

		[Test]
		public void EnterTextByID()
		{
			FirstPage.EnterTextByID("I used IDs to Enter this Text!");
			FirstPage.ClickGoByID();
			FirstPage.WaitForNoActivityIndicator();
		}

		[Test]
		public void SelectItemOnListView()
		{
			FirstPage.ClickListViewButton();
			ListViewPage.TapListItemNumber(9);
		}

		[Test]
		public void SelectItemOnListViewByID()
		{
			FirstPage.ClickListViewButtonByID();
			ListViewPage.TapListItemNumber(9);
		}

		[Test]
		public void RotateScreenAndEnterTextByID()
		{
			FirstPage.RotateScreenToLandscape();
			FirstPage.EnterText("The Screen Orientation Is Landscape");
			FirstPage.ClickGoByID();
			FirstPage.WaitForNoActivityIndicator();
			FirstPage.RotateScreenToPortrait();
			FirstPage.EnterText("The Screen Orientation Is Portrait");
			FirstPage.ClickGoByID();
			FirstPage.WaitForNoActivityIndicator();
		}
	}
}

