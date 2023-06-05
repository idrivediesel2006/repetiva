using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Repetiva.Models;

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
            var waitTime = 60000; // default to 60 seconds
            if (ConfigHelper.BrowserSettings is not null)
                waitTime = ConfigHelper.BrowserSettings.WaitTimeInMilliseconds;

            Thread.Sleep(waitTime);
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

            if (ConfigHelper.ProgramSettings is not null &&
                ConfigHelper.ProgramSettings.ScreenshotLocation is not null &&
                !Directory.Exists(ConfigHelper.ProgramSettings.ScreenshotLocation))
                Directory.CreateDirectory(ConfigHelper.ProgramSettings.ScreenshotLocation);

            string fqName = $"{ConfigHelper.ProgramSettings?.ScreenshotLocation}\\image-{DateTime.Now.ToString("yyyyMMddHHmmss")}.png";
            screenshot.SaveAsFile(fqName, ScreenshotImageFormat.Png);
        }

        public static IWebElement WaitUntilElementExists(this IWebDriver webDriver, By elementLocator)
        {
            if (ConfigHelper.BrowserSettings is not null)
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(ConfigHelper.BrowserSettings.WaitTimeInSeconds));
                IWebElement webElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
                return webElement;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}