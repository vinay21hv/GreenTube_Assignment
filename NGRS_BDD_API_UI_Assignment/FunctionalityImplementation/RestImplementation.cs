
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;

namespace NGRS_BDD_API_UI_Assignment.Base
{
    class RestImplementation
    {
        public RestClient client = null;
        public string wasAccepted = null;
        

        public RestClient SetEndpoint(string endpointUrl)
        {
            client = new RestClient(endpointUrl);
            return client;
        }


        public RestResponse Login(string username, string password)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddJsonBody(Data.LoginJsonData(username, password));
            var response = client.Execute(request);
            foreach (var item in response.Headers)
            {
                string[] keyPairs = item.ToString().Split('=');
                if (keyPairs[0] == "x-nrgs-auth-token-jwt")
                {
                    Data.BearerToken = keyPairs[1];
                    break;
                }
            }
            return (RestResponse)response;
        }


        public RestResponse AddConsent(string consentType, string acceptance)
        {
            var request = new RestRequest(Method.POST);
            request.AddParameter("consentType", consentType, ParameterType.QueryString);
            request.AddParameter("accepted", acceptance, ParameterType.QueryString);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddHeader("Authorization", "Bearer " + Data.BearerToken);
            var response = client.Execute(request);
            return (RestResponse)response;
        }


        public RestResponse GetConsent(string consentTypeValue)
        {
            var request = new RestRequest(Method.GET);
            request.AddParameter("consentType", consentTypeValue, ParameterType.QueryString);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddHeader("Authorization", "Bearer " + Data.BearerToken);
            var response = client.Execute(request);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
            wasAccepted = jsonResponse.lastKnownConsent.wasAccepted;
            return (RestResponse)response;
        }

 
        public RestResponse UpgradeToFullRegistration()
        {
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(Data.RegistrationJsonData());
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddHeader("Authorization", "Bearer " + Data.BearerToken);
            var response = client.Execute(request);
            return (RestResponse)response;
        }

        public RestResponse MakePurchase()
        {
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(Data.PaymentJsonData());
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddHeader("Authorization", "Bearer " + Data.BearerToken);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var response = client.Execute(request);
            return (RestResponse)response;
        }
    }
}
