using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using System.Threading;
using static lab_3.Browser;

namespace lab_3
{
    public class UnitTest
    {
        private string Email = "henayah450@zaelmo.com";
        private string Password = "E@s7K7AL2LSaG8g";
        private string FirstName = "K";
        private string LastName = "L";

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

        [Test]
        public void Auth()
        {
            WebDriver.Navigate().GoToUrl("http://automationpractice.com");

            StringAssert.AreEqualIgnoringCase("My Store", WebDriver.Title);

            var signInBtn = FindElement("login", FindBy.ClassName);
            Assert.NotNull(signInBtn);
            signInBtn.Click();

            Thread.Sleep(1000);

            StringAssert.AreEqualIgnoringCase("Login - My Store", WebDriver.Title);

            var emailInput = FindElement("email", FindBy.Id);
            Assert.NotNull(emailInput);
            emailInput.SendKeys(Email);

            var passwordInput = FindElement("passwd", FindBy.Id);
            Assert.NotNull(passwordInput);
            passwordInput.SendKeys(Password);

            var submitLogin = FindElement("SubmitLogin", FindBy.Id);
            Assert.NotNull(submitLogin);
            submitLogin.Click();

            Thread.Sleep(2000);

            StringAssert.AreEqualIgnoringCase("My account - My Store", WebDriver.Title);

            var account = FindElement("account", FindBy.ClassName);
            Assert.NotNull(account);

            StringAssert.AreEqualIgnoringCase(FirstName + " " + LastName, account.Text);
        }

        [Test]
        public void SubmitEmptyEmail()
        {
            WebDriver.Navigate().GoToUrl("http://automationpractice.com");

            StringAssert.AreEqualIgnoringCase("My Store", WebDriver.Title);

            var signInBtn = FindElement("login", FindBy.ClassName);
            Assert.NotNull(signInBtn);
            signInBtn.Click();

            Thread.Sleep(1000);

            StringAssert.AreEqualIgnoringCase("Login - My Store", WebDriver.Title);

            var submitLogin = FindElement("SubmitLogin", FindBy.Id);
            Assert.NotNull(submitLogin);
            submitLogin.Click();

            Thread.Sleep(4000);

            var alert = FindElements("alert", FindBy.ClassName);
            var errors = alert.SelectMany(_ => _.FindElements("li", FindBy.TagName).Select(li => li.Text));

            Assert.True(errors.Contains("An email address required."));
        }

        [Test]
        public void SubmitEmptyPassword()
        {
            WebDriver.Navigate().GoToUrl("http://automationpractice.com");

            StringAssert.AreEqualIgnoringCase("My Store", WebDriver.Title);

            var signInBtn = FindElement("login", FindBy.ClassName);
            Assert.NotNull(signInBtn);
            signInBtn.Click();

            Thread.Sleep(1000);

            StringAssert.AreEqualIgnoringCase("Login - My Store", WebDriver.Title);

            var emailInput = FindElement("email", FindBy.Id);
            Assert.NotNull(emailInput);
            emailInput.SendKeys(Email);

            var submitLogin = FindElement("SubmitLogin", FindBy.Id);
            Assert.NotNull(submitLogin);
            submitLogin.Click();

            Thread.Sleep(4000);

            var alert = FindElements("alert", FindBy.ClassName);
            var errors = alert.SelectMany(_ => _.FindElements("li", FindBy.TagName).Select(li => li.Text));

            Assert.True(errors.Contains("Password is required."));
        }

        [Test]
        public void ParticipantScript1()
        {
            Auth();

            var shirts = FindElement("#block_top_menu > ul > li > a[title='T-shirts']");
            Assert.NotNull(shirts);
            shirts.Click();

            Thread.Sleep(1000);

            var product = FindElement(".right-block a[title='Faded Short Sleeve T-shirts']");
            Assert.NotNull(product);
            product.Click();

            Thread.Sleep(2000);

            var addToCard = FindElement("button[name='Submit']");
            Assert.NotNull(addToCard);
            addToCard.Click();

            Thread.Sleep(1000);

            var closeModel = FindElement("cross", FindBy.ClassName);
            Assert.NotNull(closeModel);
            closeModel.Click();

            var card = FindElement("a[title='View my shopping cart']");
            Assert.NotNull(card);
            card.Click();

            var productName = FindElement(".cart_item .product-name")?.Text;
            Assert.NotNull(productName);
            StringAssert.AreEqualIgnoringCase("Faded Short Sleeve T-shirts", productName);

            var totalPrice = FindElement("total_price", FindBy.Id)?.Text;
            Assert.NotNull(totalPrice);
            StringAssert.AreEqualIgnoringCase("$19.25", totalPrice);

            var plus = FindElement("cart_quantity_up", FindBy.ClassName);
            Assert.NotNull(plus);
            plus.Click();

            Thread.Sleep(2000);

            var totalPriceAfterClickPlus = FindElement("total_price", FindBy.Id)?.Text;
            Assert.NotNull(totalPriceAfterClickPlus);
            var number = totalPrice.Replace("$", string.Empty);
            var newTotalPrice = double.Parse(number) * 2;
            StringAssert.AreEqualIgnoringCase($"${newTotalPrice}", totalPriceAfterClickPlus);
        }

        [Test]
        public void SearchProduct()
        {
            Auth();

            var productQuery = "Printed Chiffon Dress";
            var searchQuery = FindElement("search_query_top", FindBy.Id);
            Assert.NotNull(searchQuery);
            searchQuery.SendKeys(productQuery);
            searchQuery.SendKeys(Keys.Return);

            Thread.Sleep(2000);

            var products = FindElements("product-container", FindBy.ClassName);
            var productSearch = products
                .FirstOrDefault(p => p.FindElement(".right-block .product-name")?.Text == productQuery);
            Assert.NotNull(productSearch);

            var pricePercent = productSearch.FindElement(".right-block .price-percent-reduction")?.Text;
            Assert.NotNull(pricePercent);
            StringAssert.AreEqualIgnoringCase("-20%", pricePercent);
        }
    }
}
