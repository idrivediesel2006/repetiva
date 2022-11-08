namespace Repetiva.Models.Config
{
    /// <summary>
    /// These are settings for the browser.
    /// </summary>
    public class BrowserSettings
    {
        /// <summary>
        /// Determines if you want to maximize the browser window.
        /// </summary>
        public bool Maximize { get; set; }

        /// <summary>
        /// The number of pixels you would like to horizontally offset the browser window.
        /// With most modern computers moving the browser window from the left most screen to the next screen on the right you can set it to 2,000.
        /// If you want to move the browser to the left you might need to use a negative number for this setting.
        /// Check your resolution settings to determine the amount of pixels you need to move the browser to another screen.
        /// </summary>
        public int XOffset { get; set; }

        /// <summary>
        /// Just like XOffset will move the browser windows horizontally, the YOffset determines the number of pixels you would like to vertically offset the browser window.
        /// </summary>
        public int YOffset { get; set; }

        /// <summary>
        /// Wait time in milliseconds. To wait for 2.5 seconds you would use 2,500 milliseconds.
        /// In the case of waiting for the broswer to complete JS execution and giving it time 
        /// to catch-up this setting is used for actual wait times.
        /// Use small fractional numbers. 
        /// </summary>
        public int WaitTimeInMilliseconds { get; set; }

        /// <summary>
        /// Wait time in seconds. 
        /// This is used for an overall wait time. 
        /// Large numbers are used here. 
        /// Default config setting is 60 seconds. 
        /// However, if an element if found sooner it returns the element as soon as it finds it.
        /// </summary>
        public int WaitTimeInSeconds { get; set; }
    }
}
