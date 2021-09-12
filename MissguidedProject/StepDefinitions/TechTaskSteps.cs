using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTask.PageObjects;

namespace TechTask.StepDefinitions
{
    [Binding]
    public sealed class TechTaskStepDefinitions
    {
        private readonly MainPage mainPage;
        private IWebDriver _driver;
        private string Under20poundsFirstDressName;
        private string Under20poundsFirstDressPrice;

        public TechTaskStepDefinitions(IWebDriver driver)
        {
            mainPage = new MainPage(driver);
            _driver = driver;
        }

        [Given(@"I am on homepage")]
        public void GivenIAmOnHomepage()
        {
            mainPage.Navigate("https://www.missguided.co.uk/");
        }

        [When(@"I select the “Dresses” category")]
        public void WhenISelectTheDressesCategory()
        {
            mainPage.DressesMenuTab.Click();
        }

        [Then(@"dresses PLP is displayed")]
        public void ThenDressesPLPIsDisplayed()
        {
            Assert.AreEqual("Dresses", mainPage.DressesHeading.Text);                                 // Assertion to verify dresses PLP is displayed
            Assert.AreEqual(40, mainPage.Under20poundsDressesTitles.Count);                           // Assertion to verify default page size is 40
            for (int i = 0; i < mainPage.Under20poundsDressesTitles.Count; i++)
            {
                Assert.That(mainPage.Under20poundsDressesTitles[i].Text, Does.Contain("dress"));      // Assertion to validate only dresses are displayed
            }
        }

        [When(@"I select an item under the value of £(.*)")]
        public void WhenISelectAnItemUnderTheValueOf(Decimal p0)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", mainPage.MaxPriceInput);
            mainPage.MaxPriceInput.SendKeys(Keys.Control + "a");
            mainPage.MaxPriceInput.SendKeys("19");
            mainPage.MaxPriceInput.SendKeys(Keys.Enter);
        }

        [Then(@"only dresses under £(.*) are displayed")]
        public void ThenOnlyDressesUnderAreDisplayed(int p0)
        {
            double DOut;
            double myNum = 19.99D;
            Thread.Sleep(3000);
            Assert.AreEqual(40, mainPage.Under20poundsDressesPrices.Count);                           // Assertion to verify default page size is 40
            for (int i = 0; i < mainPage.Under20poundsDressesPrices.Count; i++)
            {
                String str = mainPage.Under20poundsDressesPrices[i].Text;
                Assert.IsTrue(str.StartsWith("£") && double.TryParse(str.Substring(1), out DOut));      // Assertion that verifies displayed currency starts with £
                Assert.IsTrue(double.Parse(str.Substring(1)) < myNum);                                  // Assertion to verify only under £20 dresses are displayed
            }
            Under20poundsFirstDressName = mainPage.Under20poundsDressesTitles[0].Text;
            Under20poundsFirstDressPrice = mainPage.Under20poundsDressesPrices[0].Text;
        }

        [When(@"I select a dress from the list")]
        public void WhenISelectADressFromTheList()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", mainPage.Under20poundsDressesTitles[0]);
            mainPage.Under20poundsDressesTitles[0].Click();
        }

        [Then(@"PDP of the selected dress should be displayed")]
        public void ThenPDPOfTheSelectedDressShouldBeDisplayed()
        {
            Assert.AreEqual(Under20poundsFirstDressName, mainPage.PDPheader.Text);                    // Assertion to verify selected dress PDP is displayed
            Assert.AreEqual(Under20poundsFirstDressPrice, mainPage.PDPprice.Text);                    // Assertion to verify selected dress PDP is displayed
        }

        [When(@"I add the item to basket")]
        public void WhenIAddTheItemToBasket()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", mainPage.AddToBasket);
            mainPage.AddToBasket.Click();
            Assert.AreEqual(1, mainPage.Basket.Text);                                                   // Assertion to verify basket has got only 1 item
            mainPage.Basket.Click();
        }

        [Then(@"selected product should be visible at checkout")]
        public void ThenSelectedProductShouldBeVisibleAtCheckout()
        {
            Assert.AreEqual(Under20poundsFirstDressName, mainPage.CheckoutProductName.Text);           // following  4 Assertions are to verify the basket product
            Assert.AreEqual(Under20poundsFirstDressPrice, mainPage.CheckoutProductPrice.Text);
            Assert.AreEqual(Under20poundsFirstDressPrice, mainPage.CheckoutProductSubTotal.Text);
            Assert.AreEqual("size: 4", mainPage.CheckoutDressSize.Text);
            Assert.AreEqual("1", mainPage.CheckoutDressQuantity.GetAttribute("value"));
        }

        [Then(@"I should be able to checkout as a guest")]
        public void ThenIShouldBeAbleToCheckoutAsAGuest()
        {
            mainPage.Email.SendKeys("test@yahoo.com");
            mainPage.FirstName.SendKeys("test firstname");
            mainPage.LastName.SendKeys("test surname");
            mainPage.Telephone.SendKeys("123456789");
            mainPage.AgeConfirmCheckBox.Click();
            mainPage.DeliveryAddress.Click();
            mainPage.DeliveryAddress.SendKeys("PR18JA");
            mainPage.FirstListInTheAddress.Click();
            mainPage.UKStandardDelivery.Click();
        }
    }
}