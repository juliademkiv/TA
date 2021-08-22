﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TA.SeleniumUtils.Wrappers
{
    internal class WebDriverFactory
    {
        public virtual IWebDriver CreateLocalChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            return new ChromeDriver(options);
        }
    }
}