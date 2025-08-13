using OpenQA.Selenium;
using System;
using System.IO;

namespace EcommerceAutomation.Utilities
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(IWebDriver driver, string testName)
        {
            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                string filePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "Screenshots",
                    $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png"
                );
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                screenshot.SaveAsFile(filePath);
                Console.WriteLine($"Screenshot saved at: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error taking screenshot: {ex.Message}");
            }
        }
    }
}
