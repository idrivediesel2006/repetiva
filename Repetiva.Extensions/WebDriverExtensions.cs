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

        public static void TakeScreenShot(this IWebDriver webDriver, ProgramSettings programSettings)
        {
            Screenshot screenshot = ((ITakesScreenshot)webDriver).GetScreenshot();

            if (!Directory.Exists(programSettings.ScreenshotLocation))
                Directory.CreateDirectory(ConfigHelper.ProgramSettings.ScreenshotLocation);

            string fqName = $"{programSettings.ScreenshotLocation}{DateTime.Now.ToShortDateString()}.jpg";
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