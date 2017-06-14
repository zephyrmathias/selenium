using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Configuration;

namespace Testing
{
    class Program
    {
        static void Main(string[] args) { }

        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver();
            PropertiesCollection.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("LandingPage"));
            PropertiesCollection.driver.Manage().Window.Maximize();
        }

        [Test]
        public void PositiveTest()
        {

            ExcelLib.PopulateInCollection(@"C:\Users\Zephyr\Desktop\positive_test.xlsx");

            int row = Int32.Parse(ConfigurationManager.AppSettings.Get("PositiveCaseNum"));

            for (int i = 1; i <= row; i++)
            {
                RegisterPageObject registerPage = new RegisterPageObject();

                string firstname = ExcelLib.ReadData(i, "firstname");
                string lastname = ExcelLib.ReadData(i, "lastname");
                string displayname = ExcelLib.ReadData(i, "displayname");
                string email = ExcelLib.ReadData(i, "email");
                string password = ExcelLib.ReadData(i, "password");
                string repassword = ExcelLib.ReadData(i, "repassword");
                string gender = ExcelLib.ReadData(i, "gender");
                string birthdayDate = ExcelLib.ReadData(i, "birthdayDate");
                string birthdayMonth = ExcelLib.ReadData(i, "birthdayMonth");
                string birthdayYear = ExcelLib.ReadData(i, "birthdayYear");
                string telephone = ExcelLib.ReadData(i, "telephone");
                string subscribe = ExcelLib.ReadData(i, "subscribe");

                registerPage.FillUserForm(firstname, lastname, displayname, email, password, repassword, gender, birthdayDate, birthdayMonth, birthdayYear, telephone, subscribe);

                Initialize();
                PropertiesCollection.driver.SwitchTo().Window(PropertiesCollection.driver.WindowHandles.Last());
            }

        }

        [Test]
        public void NegativeTest()
        {

            ExcelLib.PopulateInCollection(@"C:\Users\Zephyr\Desktop\negative_test.xlsx");

            int row = Int32.Parse(ConfigurationManager.AppSettings.Get("NegativeCaseNum"));

            for (int i = 1; i <= row; i++)
            {
                RegisterPageObject registerPage = new RegisterPageObject();

                string firstname = ExcelLib.ReadData(i, "firstname");
                string lastname = ExcelLib.ReadData(i, "lastname");
                string displayname = ExcelLib.ReadData(i, "displayname");
                string email = ExcelLib.ReadData(i, "email");
                string password = ExcelLib.ReadData(i, "password");
                string repassword = ExcelLib.ReadData(i, "repassword");
                string gender = ExcelLib.ReadData(i, "gender");
                string birthdayDate = ExcelLib.ReadData(i, "birthdayDate");
                string birthdayMonth = ExcelLib.ReadData(i, "birthdayMonth");
                string birthdayYear = ExcelLib.ReadData(i, "birthdayYear");
                string telephone = ExcelLib.ReadData(i, "telephone");
                string subscribe = ExcelLib.ReadData(i, "subscribe");

                registerPage.FillUserForm(firstname, lastname, displayname, email, password, repassword, gender, birthdayDate, birthdayMonth, birthdayYear, telephone, subscribe);

                Initialize();
                PropertiesCollection.driver.SwitchTo().Window(PropertiesCollection.driver.WindowHandles.Last());
            }

        }

        [TearDown]
        public void CleanUp()
        {
            PropertiesCollection.driver.Close();
        }

    }
}
