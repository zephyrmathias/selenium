using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Testing
{
    class RegisterPageObject
    {

        public RegisterPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Name, Using = "firstname")]
        public IWebElement FirstnameInputTag { get; set; }

        [FindsBy(How = How.Name, Using = "lastname")]
        public IWebElement LastnameInputTag { get; set; }

        [FindsBy(How = How.Name, Using = "display_name")]
        public IWebElement DisplaynameInputTag { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement EmailInputTag { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement PasswordInputTag { get; set; }

        [FindsBy(How = How.Name, Using = "re_password")]
        public IWebElement RePasswordInputTag { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='gender'][@value='F']")]
        public IWebElement FemailRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='gender'][@value='M']")]
        public IWebElement MaleRadioBtn { get; set; }

        [FindsBy(How = How.Id, Using = "birthday_day")]
        public IWebElement BirthdayDateDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "birthday_month")]
        public IWebElement BirthdayMonthDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "birthday_year")]
        public IWebElement BirthdayYearDropdown { get; set; }

        [FindsBy(How = How.Name, Using = "telephone")]
        public IWebElement TelephoneInputTag { get; set; }

        [FindsBy(How = How.Name, Using = "subscribe")]
        public IWebElement SubscribeRadioBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "button")]
        public IWebElement SubmitBtn { get; set; }

        public void FillUserForm(string firstname, string lastname, string displayname, string email, string password, string repassword, string gender, string day, string month, string year, string telephone, string subscribe)
        {
            FirstnameInputTag.EnterText(firstname);
            LastnameInputTag.EnterText(lastname);
            DisplaynameInputTag.EnterText(displayname);
            EmailInputTag.EnterText(email);
            PasswordInputTag.EnterText(password);
            RePasswordInputTag.EnterText(repassword);
            
            if (gender.ToLower() == "f")
            {
                FemailRadioBtn.Clicks();
            }

            if (gender.ToLower() == "m")
            {
                MaleRadioBtn.Clicks();
            }

            BirthdayDateDropdown.SelectDropDown(day);
            BirthdayMonthDropdown.SelectDropDown(month);
            BirthdayYearDropdown.SelectDropDown(year);

            TelephoneInputTag.EnterText(telephone);

            if (subscribe.ToLower() == "yes")
            {
                SubscribeRadioBtn.Clicks();
            }

            SubmitBtn.Clicks();

        }

    }
}
