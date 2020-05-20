using lab_4.Factories;
using lab_4.PageObjects.EntryPages.My_Store;
using lab_4.PageObjects.EntryPages.My_Store.Modal;
using lab_4.PageObjects.EntryPages.My_Store.Product;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using static lab_4.Utils.Browser;

namespace lab_4
{
    public class Tests
    {
        private string Email = "henayah450@zaelmo.com";
        private string Password = "E@s7K7AL2LSaG8g";

        [SetUp]
        public void Setup()
        {
            InitWebDriver();
        }

        [TearDown]
        public void Cleanup()
        {
            Dispose();
        }

        private void Auth()
        {
            WebDriver.Navigate().GoToUrl("http://automationpractice.com");

            StringAssert.AreEqualIgnoringCase("My Store", WebDriver.Title);

            var mainPage = EntryPageFactory.Create<MainMyStore>();

            mainPage.SignIn.Click();

            Thread.Sleep(1000);

            var loginPage = EntryPageFactory.Create<LoginMyStore>();

            Assert.NotNull(loginPage.Email);
            loginPage.Email.SendKeys(Email);

            Assert.NotNull(loginPage.Password);
            loginPage.Password.SendKeys(Password);

            Assert.NotNull(loginPage.SubmitLogin);
            loginPage.SubmitLogin.Click();

            Thread.Sleep(2000);

            StringAssert.AreEqualIgnoringCase("My account - My Store", WebDriver.Title);
        }

        [Test]
        public void ParticipantScript1()
        {
            Auth();

            var mainPage = EntryPageFactory.Create<MainMyStore>();

            mainPage.GoToWomenSection.Click();

            var womenSectionPage = EntryPageFactory.Create<WomenMyStore>();

            Assert.AreEqual(7, womenSectionPage.Products.Count());

            var yellowProducts = womenSectionPage.Products
                .Where(product => product.Colors.Any(color => color.ColorName == "yellow")).ToList();

            Assert.AreEqual(3, yellowProducts.Count);

            womenSectionPage.ViewList.Click();

            Thread.Sleep(1000);

            Assert.True(womenSectionPage.Products.All(product => !string.IsNullOrEmpty(product.Description)));
        }

        [Test]
        public void ParticipantScript2()
        {
            Auth();

            var mainPage = EntryPageFactory.Create<MainMyStore>();

            mainPage.GoToWomenSection.Click();

            var womenSectionPage = EntryPageFactory.Create<WomenMyStore>();

            var product = womenSectionPage.Products
                .FirstOrDefault(_ => _.Name == "Faded Short Sleeve T-shirts");

            product.Open();

            var productPage = EntryPageFactory.Create<ProductMyStore>();

            productPage.SendToFriend.Click();

            var sendToFriend = EntryPageFactory.Create<SendToFriendModal>();

            StringAssert.StartsWith("Name of your friend", sendToFriend.NameFriendLable);

            Assert.NotNull(sendToFriend.Send);
        }

        [Test]
        public void ParticipantScript3()
        {
            Auth();

            var mainPage = EntryPageFactory.Create<MainMyStore>();

            mainPage.GoToWomenSection.Click();

            var womenSectionPage = EntryPageFactory.Create<WomenMyStore>();

            var product = womenSectionPage.Products
                .FirstOrDefault(_ => _.Name == "Faded Short Sleeve T-shirts");

            product.Open();

            var productPage = EntryPageFactory.Create<ProductMyStore>();

            productPage.AddToCard.Click();

            Thread.Sleep(2000);

            EntryPageFactory.Create<AddToShoppingCardModal>().Close.Click();

            productPage.OpenCard.Click();

            Thread.Sleep(2000);

            var orderPage = EntryPageFactory.Create<OrderMyStore>();

            Assert.True(orderPage.Products.All(_ => !string.IsNullOrEmpty(_.PhotoUrl)));

            Assert.NotNull(orderPage.Footer.Email);
            Assert.NotNull(orderPage.Footer.Phone);
        }
    }
}