using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Tests;

namespace automation
{
     public class CategoryItemPageObject
     {
        public CategoryItemPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//span[@id='buy-button']")]
        public IWebElement buyButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "increase")]
        public IWebElement incrementButton{ get; set; }

        [FindsBy(How = How.LinkText, Using = "Završi kupovinu")]
        public IWebElement Cart { get; set; }

        public CartPageObject AddToBasket()
        {
            buyButton.Clicks();
            incrementButton.Clicks();
            Cart.Clicks();
            return new CartPageObject();
        }  
    }
}
