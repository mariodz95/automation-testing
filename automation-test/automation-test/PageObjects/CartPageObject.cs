using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Tests;

namespace automation
{
    public class CartPageObject
    {

       public CartPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='desktop-cart-button']/img")]
        public IWebElement cart { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@onclick=\"window.location='/kosarica_prijava.aspx'\"]")]
        public IWebElement nextButton1 { get; set; }

        [FindsBy(How = How.ClassName, Using = "kosarica-next")]
        public IWebElement nextButton2 { get; set; }

        [FindsBy(How = How.Id, Using = "napomena")]
        public IWebElement remarkTxt { get; set; }

        [FindsBy(How = How.Id, Using = "preuzimanje")]
        public IWebElement pickUp { get; set; }

        [FindsBy(How = How.Id, Using = "preuzimanje-select")]
        public IWebElement dropdown { get; set; }

        [FindsBy(How = How.Id, Using = "kartice")]
        public IWebElement payment { get; set; }

        [FindsBy(How = How.ClassName, Using = "kosarica-next")]
        public IWebElement nextButton3 { get; set; }


        public void Pay(string textInput)
        {
            cart.Clicks();
            nextButton1.Clicks();
            nextButton2.Clicks();
            pickUp.Clicks();
            dropdown.SelectDropDown("Osijek");
            payment.Clicks();
            remarkTxt.EnterText(textInput);
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("kosarica-next")));
            nextButton3.Clicks();
        }

 
    }
}
