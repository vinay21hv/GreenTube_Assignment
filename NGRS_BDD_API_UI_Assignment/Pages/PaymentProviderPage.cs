using NGRS_BDD_API_UI_Assignment.ApplicationLayer;
using NGRS_BDD_API_UI_Assignment.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace NGRS_BDD_API_UI_Assignment.Pages
{
    class PaymentProviderPage : BasePage
    {
        public PaymentProviderPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "epsIssuerSelect")]
        private IWebElement BankList { get; set; }

        [FindsBy(How = How.Id, Using = "mainSubmit")]
        private IWebElement ContinueButton { get; set; }

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
        public LoginPage ClickContinueButton()
        {
            Utils.ClickElement(ContinueButton);
            return new LoginPage(Driver);
        }
    }
}
