using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;
using Tests;

namespace automation
{
    public class LoginPageObject 
    {
        public LoginPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Name, Using = "username")]
        public IWebElement username { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement password { get; set; }

        [FindsBy(How = How.Name, Using = "submit")]
        public IWebElement submit { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href='/profile.aspx']")]
        public IWebElement login { get; set; }

        public HomePageObject Login(string userName, string _password)
        {
            login.Click();

            username.EnterText(userName);
            password.EnterText(_password);

            submit.Clicks();
            return new HomePageObject();
        }
    }
}
