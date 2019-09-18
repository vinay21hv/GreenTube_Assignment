using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGRS_BDD_API_UI_Assignment.ApplicationLayer
{
    class Data
    {
        public static string BearerToken { get; set; }
        public static string PaymentURL { get; set; }


        public static dynamic LoginJsonData(string username, string password)
        {
            var JsonBody = new
            {
                nickname = username,
                password = password,
                autologin = "true"
            };
            return JsonBody;
        }

        public static dynamic RegistrationJsonData()
        {
            dynamic JsonBody = new
            {
                firstName = "Jonatha",
                lastName = "Doey",
                isMale = true,
                countryCode = "AT",
                city = "Vienna",
                zip = "1050",
                street = "Wiedner Hauptstraße 94",
                phonePrefix = 43,
                phoneNumber = "12345678",
                securityQuestionTag = "squestion_name_of_first_pet",
                securityAnswer = "Dany"
            };
            return JsonBody;
        }

        public static dynamic PaymentJsonData()
        {
            dynamic JsonBody = new
            {
                item = "m",
                paymentTypeId = "adyenEPS",
                country = "AT",
                landingUrl = "https://www.gametwist.com/en/?modal=shop"
            };
            return JsonBody;
        }

    }
}
