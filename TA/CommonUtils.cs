﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;

namespace TA
{
    public class CommonUtils
    {
        public void PrintLogs(string LogType, IWebDriver driver)
        {
            var _logs = driver.Manage().Logs;

            try
            {
                var browserLogs = _logs.GetLog(LogType);
                if(browserLogs.Count > 0)
                {
                    var filePath = $"{Path.GetTempPath()}ConsoleLogs-{Guid.NewGuid()}.txt";
                    File.WriteAllText(filePath, "Begin Log: ");

                    foreach (var log in browserLogs)
                    {
                        // log the message in a file
                        StreamWriter sw = File.AppendText(filePath);
                        sw.WriteLine(log.ToString());
                        sw.Close();
                    }
                    TestContext.AddTestAttachment(filePath, "Browser Logs");
                }
            }
            catch
            {
                Console.WriteLine("No Logs Present");
            }
        }
    }
}
