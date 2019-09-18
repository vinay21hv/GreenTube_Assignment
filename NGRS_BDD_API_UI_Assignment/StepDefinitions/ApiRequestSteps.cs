using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using NGRS_BDD_API_UI_Assignment.ApplicationLayer;
using System;
using TechTalk.SpecFlow;

namespace NGRS_BDD_API_UI_Assignment.StepDefinitions
{
    [Binding]
    public class ApiRequestSteps
    {
        private readonly RestImplementation Rest = new RestImplementation();

        private RestResponse response = null;


        [Given(@"I have endpoint ""(.*)""")]
        public void GivenIHaveEndpoint(string url)
        {
            Rest.SetEndpoint(url);
        }

        [When(@"I perform POST operation to login with user ""(.*)"" and ""(.*)""")]
        public void WhenIPerformPOSTOperationToLoginWithUserAnd(string nickname, string password)
        {
            response = Rest.Login(nickname, password);
        }

        [Then(@"I should see the status code for login as (.*)")]
        public void ThenIShouldSeeTheStatusCodeForLoginAs(int statuscode)
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(statuscode), "Login failed");
        }

        [When(@"I perform POST operation to add consent for ""(.*)"" with ""(.*)""")]
        public void WhenIPerformPOSTOperationToAddConsentForWith(string consentType, string acceptance)
        {
            response = Rest.AddConsent(consentType, acceptance);
        }

        [Then(@"I should see the status code for add consent as (.*)")]
        public void ThenIShouldSeeTheStatusCodeForAddConsentAs(int statuscode)
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(statuscode), "Add consent step failed");
        }

        [When(@"I perform GET operation to verify consent for ""(.*)""")]
        public void WhenIPerformGETOperationToVerifyConsentFor(string consentTypeValue)
        {
            response = Rest.GetConsent(consentTypeValue);
        }
        [Then(@"I should see the status code for verify consent as (.*)")]
        public void ThenIShouldSeeTheStatusCodeForVerifyConsentAs(int statuscode)
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(statuscode), "Get consent step failed");
        }

        [Then(@"I should see the ""(.*)"" as ""(.*)""")]
        public void ThenIShouldSeeTheAs(string consentParam, string consentValue)
        {
            //Assert.That(Rest.wasAccepted, Is.EqualTo(consentValue), $"Consent value not true");
            StringAssert.AreEqualIgnoringCase(consentValue, Rest.wasAccepted);
        }

        [When(@"I perform POST operation to Upgrade To Full Registration")]
        public void WhenIPerformPOSTOperationToUpgradeToFullRegistration()
        {
            response = Rest.UpgradeToFullRegistration();
        }

        [Then(@"I should see the status code for full registration as (.*)")]
        public void ThenIShouldSeeTheStatusCodeForFullRegistrationAs(int statuscode)
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(statuscode), "Full registration step failed");
        }

        [When(@"I perform POST operation for item purchase")]
        public void WhenIPerformPOSTOperationForItemPurchase()
        {
            response = Rest.MakePurchase();
        }

        [Then(@"I should see the status code for purchase as (.*)")]
        public void ThenIShouldSeeTheStatusCodeForPurchaseAs(int statuscode)
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(statuscode), "Purchase step failed");
        }

        [Then(@"I capture payment URL from the response")]
        public void ThenICapturePaymentURLFromTheResponse()
        {
            JObject obs = JObject.Parse(response.Content);
            Data.PaymentURL = obs["paymentRedirectUrl"].ToString();
            Console.WriteLine(Data.PaymentURL);
        }
    }
}
