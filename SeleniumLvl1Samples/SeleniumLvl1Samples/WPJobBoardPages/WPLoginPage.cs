using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumLvl1Samples.WPJobBoardPages
{
    public class WPLoginPage
    {
        private IWebDriver webDriver;

        public IWebElement tbx_UserName { get { return webDriver.FindElement(By.Id("user_login")); } }
        public IWebElement tbx_UserPass { get { return webDriver.FindElement(By.Id("user_pass")); } }

        
        public WPLoginPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void ClickLogin()
        {
            webDriver.FindElement(By.Id("wp-submit")).Click();
        }

        public void LogIn(string username, string password)
        {
            tbx_UserName.SendKeys(username);
            tbx_UserPass.SendKeys(password);
        }
    }
}
