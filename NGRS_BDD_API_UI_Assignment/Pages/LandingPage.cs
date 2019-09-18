using NGRS_BDD_API_UI_Assignment.ApplicationLayer;
using NGRS_BDD_API_UI_Assignment.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NGRS_BDD_API_UI_Assignment.Pages
{
    class LandingPage : BasePage
    {
        public LandingPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Next']")]
        private IWebElement NextButton { get; set; }

        public PaymentProviderPage ClickNextButton()
        {
            Utils.WaitUntilElementToBeClickable(NextButton, 20, Driver);
            Utils.ClickElement(NextButton);
            return new PaymentProviderPage(Driver);
        }
    }
}
