using OpenQA.Selenium;
using System.Collections.Generic;

namespace TechTask.PageObjects
{
    internal class MainPage : BasePage
    {
        private IWebDriver _driver;

        public MainPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public IWebElement DressesMenuTab => _driver.FindElement(By.XPath("//h5[contains(text(),'dresses')]"));
        public IWebElement DressesHeading => _driver.FindElement(By.XPath("//h1[contains(text(),'Dresses')]"));

        public IWebElement MaxPriceInput => _driver.FindElement(By.XPath("//input[@data-test='range-max-input']"));

        public IWebElement PDPheader => _driver.FindElement(By.TagName("h1"));

        public IWebElement PDPprice => _driver.FindElement(By.XPath("//body/div[@id='root']/div[3]/div[1]/div[2]/div[1]/div[1]/span[1]"));

        public IWebElement AddToBasket => _driver.FindElement(By.XPath("//button[@id='add-to-bag']"));

        public IWebElement Basket => _driver.FindElement(By.XPath("//div[@class='exiGc2F1A6ThgurZflCR7']//span"));

        public IWebElement CheckoutProductName => _driver.FindElement(By.XPath("//h2[@class='product-name']//a"));

        public IWebElement CheckoutProductPrice => _driver.FindElement(By.XPath("//span[@class='cart-price']//span"));

        public IWebElement CheckoutProductSubTotal => _driver.FindElement(By.XPath("//div[@class='order-summary__totals']//dl//dd/span"));

        public IWebElement CheckoutDressSize => _driver.FindElement(By.XPath("//div[@id='size-qty']//ul//li"));

        public IWebElement CheckoutDressQuantity => _driver.FindElement(By.XPath("//div[@class='quantity']//input"));

        public IWebElement Email => _driver.FindElement(By.XPath("//input[@id='lookup-email']"));

        public IWebElement FirstName => _driver.FindElement(By.XPath("//input[@id='shipping:firstname']"));

        public IWebElement LastName => _driver.FindElement(By.XPath("//input[@id='shipping:lastname']"));

        public IWebElement Telephone => _driver.FindElement(By.XPath("//input[@id='shipping:telephone']"));

        public IWebElement AgeConfirmCheckBox => _driver.FindElement(By.XPath("//input[@id='shipping-age-confirmation-checkbox']"));

        public IWebElement DeliveryAddress => _driver.FindElement(By.XPath("//label[contains(text(), 'Delivery Address')]"));

        public IWebElement FirstListInTheAddress => _driver.FindElement(By.XPath("//div[@class='pcaitem pcafirstitem pcalastitem pcaselected']//span"));

        public IWebElement UKStandardDelivery => _driver.FindElement(By.XPath("//body/div[@id='wrapper']/div[3]/div[1]/div[1]/main[1]/section[1]/div[1]/section[1]/div[1]/div[2]/div[3]/div[1]/div[1]/form[1]/ul[1]/li[1]/label[1]"));

        public IList<IWebElement> Under20poundsDressesPrices => _driver.FindElements(By.XPath("//div//span[@data-test='price']"));

        public IList<IWebElement> Under20poundsDressesTitles => _driver.FindElements(By.XPath("//a[@class='_4G4vRJpjsp5WnIexToSJN']"));
    }
}