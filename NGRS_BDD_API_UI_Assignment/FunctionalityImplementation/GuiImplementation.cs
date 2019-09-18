using NGRS_BDD_API_UI_Assignment.Base;
using NGRS_BDD_API_UI_Assignment.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGRS_BDD_API_UI_Assignment.FunctionalityImplementation
{
    public class GuiImplementation : BasePage
    {
        //IWebDriver driver;
        public GuiImplementation(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Next']")]
        private IWebElement NextButton { get; set; }

        [FindsBy(How = How.Id, Using = "epsIssuerSelect")]
        private IWebElement BankList { get; set; }

        [FindsBy(How = How.Id, Using = "mainSubmit")]
        private IWebElement ContinueButton { get; set; }

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

        public void ClickNextButton()
        {
            Utils.WaitUntilElementToBeClickable(NextButton, 20, Driver);
            Utils.ClickElement(NextButton);
        }
        
        public void SelectBank(String bankname)
        {
            SelectElement PaymentProvider = new SelectElement(BankList);
            PaymentProvider.SelectByText(bankname);
        }
        public bool VerifyPaymentPageLoaded()
        {
            Utils.WaitUntilElementToBeClickable(ContinueButton, 20, Driver);
            return BankList.Displayed;
        }
        public void ClickContinueButton()
        {
            Utils.ClickElement(ContinueButton);
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
            CancelButton.Click();
        }

        public string GetPageTitle(string Title)
        {
            Utils.WaitForPageTitle(20, Driver, Title);
            return Driver.Title;
        }
    }
}
