using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace EcommerceAutomation.Utilities
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver(string browserName)
        {
            IWebDriver driver;

            switch (browserName.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException("Unsupported browser: " + browserName);
            }

            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
