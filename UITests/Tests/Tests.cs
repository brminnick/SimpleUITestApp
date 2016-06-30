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
			//Arrange
			var textInput = "Hello World";

			//Act
			FirstPage.EnterText(textInput);
			FirstPage.ClickGo();
			FirstPage.WaitForNoActivityIndicator();

			//Assert
			Assert.AreEqual(FirstPage.GetEntryFieldText(), textInput);
		}

		[Test]
		public void EnterTextByID()
		{
			//Arrange
			var textInput = "I used IDs to Enter this Text!";

			//Act
			FirstPage.EnterTextByID(textInput);
			FirstPage.ClickGoByID();
			FirstPage.WaitForNoActivityIndicator();

			//Assert
			Assert.AreEqual(FirstPage.GetEntryFieldTextByID(), textInput);
		}

		[Test]
		public void SelectItemOnListView()
		{
			//Arrange
			var listItemNumber = 9;
			var expectedAlertString = $"You Selected Number {listItemNumber}";

			//Act
			FirstPage.ClickListViewButton();
			ListViewPage.TapListItemNumber(listItemNumber);

			//Assert
			Assert.AreEqual(expectedAlertString, ListViewPage.GetAlertText(listItemNumber));
		}

		[Test]
		public void SelectItemOnListViewByID()
		{
			//Arrange
			var listItemNumber = 9;
			var expectedAlertString = $"You Selected Number {listItemNumber}";

			//Act
			FirstPage.ClickListViewButtonByID();
			ListViewPage.TapListItemNumber(listItemNumber);

			//Assert
			Assert.AreEqual(expectedAlertString, ListViewPage.GetAlertText(listItemNumber));
		}

		[Test]
		public void RotateScreenAndEnterTextByID()
		{
			//Arrange
			var entryTextLandcape = "The Screen Orientation Is Landscape";
			var entryTextPortrait = "The Screen Orientation Is Portrait";

			//Act
			FirstPage.RotateScreenToLandscape();
			FirstPage.EnterText(entryTextLandcape);
			FirstPage.ClickGoByID();
			FirstPage.WaitForNoActivityIndicator();

			//Assert
			Assert.AreEqual(FirstPage.GetEntryFieldTextByID(), entryTextLandcape);

			//Act
			FirstPage.RotateScreenToPortrait();
			FirstPage.EnterText(entryTextPortrait);
			FirstPage.ClickGoByID();
			FirstPage.WaitForNoActivityIndicator();

			//Assert
			Assert.AreEqual(FirstPage.GetEntryFieldTextByID(), entryTextPortrait);
		}
	}
}

