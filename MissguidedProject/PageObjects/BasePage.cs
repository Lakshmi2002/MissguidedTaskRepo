using OpenQA.Selenium;
using System;

namespace TechTask.PageObjects
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public string GetPageUrl()
        {
            return Driver.Url;
        }

        private static readonly Random random = new Random();

        public static int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        public bool IsPageLoaded(By pageLocator)
        {
            try
            {
                return Driver.FindElement(pageLocator).Displayed;
            }
            catch (Exception)
            {
                Console.WriteLine($@"No page found with locator: {pageLocator}");
                throw;
            }
        }

        public bool IsPageLoaded(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (Exception)
            {
                Console.WriteLine($@"No page found with element: {element}");
                throw;
            }
        }
    }
}