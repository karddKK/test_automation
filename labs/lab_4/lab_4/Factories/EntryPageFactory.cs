using lab_4.PageObjects;
using lab_4.Utils;
using OpenQA.Selenium;

namespace lab_4.Factories
{
	public static class EntryPageFactory
	{
		public static TPage Create<TPage>(IWebDriver driver = null) where TPage : PageBase, new()
		{
			return new TPage
			{
				Driver = driver ?? Browser.WebDriver
			};
		}
	}
}
