using NGRS_BDD_API_UI_Assignment.ApplicationLayer;
using NGRS_BDD_API_UI_Assignment.Helpers;
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

        [FindsBy(How = How.XPath, Using = "//div[@class='messagebox messagebox_error']")]
        private IWebElement ErrorMsg { get; set; }

        [FindsBy(How = How.Id, Using = "gebForm:j_id74")]
        private IWebElement CancelButton { get; set; }

        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public bool VerifyLoginPageLoaded()
        {
            Utils.WaitUntilElementToBeClickable(LoginButton, 20, Driver);
            return UserIdTextbox.Displayed;
        }
        public void EnterUserId(string userid)
        {
            Utils.EnterText(UserIdTextbox, userid);
        }
        public void EnterPin(string pin)
        {
            Utils.EnterText(PinTextbox, pin);
        }
        public void ClickLoginButton()
        {
            Utils.ClickElement(LoginButton);
        }

        public bool VerifyErrorMsg()
        {
            return ErrorMsg.Displayed;
        }

        public string GetErrorText()
        {
            return ErrorMsg.Text;
        }
        public void ClickCancelButton()
        {
            Utils.ClickElement(CancelButton);
        }

        public string GetPageTitle(string Title)
        {
            Utils.WaitForPageTitle(20, Driver, Title);
            return Driver.Title;
        }
    }
}
