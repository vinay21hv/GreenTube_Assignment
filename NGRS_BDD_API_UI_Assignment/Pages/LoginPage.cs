using NGRS_BDD_API_UI_Assignment.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace NGRS_BDD_API_UI_Assignment.Pages
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "gebForm:verf_ID")]
        private IWebElement UserIdTextbox { get; set; }

        [FindsBy(How = How.Id, Using = "gebForm:pin_ID")]
        private IWebElement PinTextbox { get; set; }

        [FindsBy(How = How.Id, Using = "gebForm:LoginCommandButton")]
        private IWebElement LoginButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "messagebox messagebox_error")]
        private IWebElement ErrorMsg { get; set; }

        [FindsBy(How = How.Id, Using = "gebForm:j_id74")]
        private IWebElement CancelButton { get; set; }

        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public bool VerifyLoginPageLoaded()
        {
            return UserIdTextbox.Displayed;
        }
        public void EnterUserId(string userid)
        {
            UserIdTextbox.Clear();
            UserIdTextbox.SendKeys(userid);
        }

        public void EnterPin(string pin)
        {
            PinTextbox.Clear();
            PinTextbox.SendKeys(pin);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public bool VerifyErrorMsg()
        {
            return ErrorMsg.Displayed;
        }

        public void ClickCancelButton()
        {
            CancelButton.Click();
        }
    }
}
