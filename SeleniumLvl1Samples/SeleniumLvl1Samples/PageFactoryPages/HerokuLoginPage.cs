using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumLvl1Samples.PageFactoryPages
{
    public class HerokuLoginPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Id, Using ="username")]
        public IWebElement tbx_UserName { get; set; }

        [FindsBy(How = How.Id, Using ="password")]
        public IWebElement tbx_UserPass { get; set; }

        [FindsBy(How=How.TagName,Using = "button")]
        public IWebElement btn_LogIn { get; set; }


        public HerokuLoginPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
           // PageFactory.InitElement(...);
        }

        public void ClickLogin()
        {
            btn_LogIn.Click();
        }

        public void LogIn(string username, string password)
        {
            tbx_UserName.SendKeys(username);
            tbx_UserPass.SendKeys(password);
        }
    }
}
