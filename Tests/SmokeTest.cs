using NUnit.Framework;
using OpenQA.Selenium;
using EcommerceAutomation.Utilities;
using EcommerceAutomation.Config;

namespace EcommerceAutomation.Tests
{
    [TestFixture]
    public class SmokeTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.CreateDriver(TestSettings.Browser);
            driver.Navigate().GoToUrl(TestSettings.BaseUrl);
        }

        [Test]
        public void Homepage_Should_Have_Title()
        {
            string title = driver.Title;
            Assert.IsNotEmpty(title, "Homepage title is empty!");
        }

        [TearDown]
        public void Cleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                ScreenshotHelper.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
            }
            driver.Quit();
        }
    }
}
