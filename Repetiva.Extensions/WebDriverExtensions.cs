using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Repetiva.Models;
using Repetiva.Models.Config;

namespace Repetiva.Extensions
{
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Performs an explicit Thread.Sleep
        /// (User sparingly)
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="browserSettings"></param>
        public static void Wait(this IWebDriver webDriver)
        {
            Thread.Sleep(ConfigHelper.BrowserSettings.WaitTimeInMilliseconds);
        }

        public static void MoveToElement(this IWebDriver webDriver, IWebElement webElement)
        {
            Actions moveToWebElement = new Actions(webDriver);
            moveToWebElement.MoveToElement(webElement);
            moveToWebElement.Perform();
        }

        public static void TakeScreenShot(this IWebDriver webDriver)
        {
            Screenshot screenshot = ((ITakesScreenshot)webDriver).GetScreenshot();

            if (!Directory.Exists(ConfigHelper.ProgramSettings.ScreenshotLocation))
                Directory.CreateDirectory(ConfigHelper.ProgramSettings.ScreenshotLocation);

            string fqName = $"{ConfigHelper.ProgramSettings.ScreenshotLocation}\\image-{DateTime.Now.ToString("yyyyMMddHHmmss")}.jpg";
            screenshot.SaveAsFile(fqName, ScreenshotImageFormat.Jpeg);
        }

        public static IWebElement WaitUntilElementExists(this IWebDriver webDriver, By elementLocator)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(ConfigHelper.BrowserSettings.WaitTimeInSeconds));
            IWebElement webElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
            return webElement;
        }
    }
}