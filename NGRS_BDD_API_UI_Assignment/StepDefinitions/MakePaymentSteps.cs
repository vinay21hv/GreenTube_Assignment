using NGRS_BDD_API_UI_Assignment.ApplicationLayer;
using NGRS_BDD_API_UI_Assignment.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using NGRS_BDD_API_UI_Assignment.Helpers;

namespace NGRS_BDD_API_UI_Assignment.StepDefinitions
{
    [Binding]
    public class MakePaymentSteps : BasePage
    {
        LandingPage landingPage;
        PaymentProviderPage paymentProviderPage;
        LoginPage loginPage;

        [Given(@"I navigate to landing page using paymentRedirect URL")]
        public void GivenINavigateToLandingPageUsingPaymentRedirectURL()
        {
            Initialize();
            landingPage = new LandingPage(Driver);
            Driver.Navigate().GoToUrl(Data.PaymentURL);
        }

        [When(@"I click Next button")]
        public void WhenIClickNextButton()
        {
            paymentProviderPage = landingPage.ClickNextButton();
        }

        [Then(@"I should see payment provider page")]
        public void ThenIShouldSeePaymentProviderPage()
        {
            Assert.IsTrue(paymentProviderPage.VerifyPaymentPageLoaded(), "Payment page not loaded");
        }

        [Then(@"select Payment provider as ""(.*)"" and click continue button")]
        public void ThenSelectPaymentProviderAsAndClickContinueButton(string bankname)
        {
            paymentProviderPage.SelectBank(bankname);
            loginPage = paymentProviderPage.ClickContinueButton();
        }

        [Then(@"I should see login page")]
        public void ThenIShouldSeeLoginPage()
        {
            Assert.IsTrue(loginPage.VerifyLoginPageLoaded(), "Login page not loaded");
        }

        [When(@"I enter ""(.*)"" and ""(.*)"" and click login button")]
        public void WhenIEnterAndAndClickLoginButton(string userid, string pin)
        {
            loginPage.EnterUserId(userid);
            loginPage.EnterPin(pin);
            loginPage.ClickLoginButton();
        }

        [Then(@"I shoud see error message ""(.*)"", ""(.*)""")]
        public void ThenIShoudSeeErrorMessage(string errMsg1, string errMsg2)
        {
            Assert.IsTrue(loginPage.VerifyErrorMsg(), "Failure message not displayed");
            string ErrorText = loginPage.GetErrorText();
            StringAssert.Contains(errMsg1, ErrorText);
            StringAssert.Contains(errMsg2, ErrorText);
        }

        [Then(@"I click cancel button")]
        public void ThenIClickCancelButton()
        {
            loginPage.ClickCancelButton();
        }

        [Then(@"I should see gametwist page title contains ""(.*)""")]
        public void ThenIShouldSeeGametwistPageTitleContains(string title)
        {
            string PageTitle= loginPage.GetPageTitle(title);
            Assert.IsTrue(PageTitle.Contains(title), "Home page not loaded");
        }

        [Then(@"I take screenshot and close the browser")]
        public void ThenITakeScreenshotAndCloseTheBrowser()
        {
            Utils.GetScreenShot();
            Driver.Quit();
        }
    }
}
