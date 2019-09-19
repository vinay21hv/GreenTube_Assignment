using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace NGRS_BDD_API_UI_Assignment.ApplicationLayer
{
    public class BasePage
    {
        public static IWebDriver Driver = null;
        public void Initialize()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Driver.Manage().Window.Maximize();
        }
       
    }
}
