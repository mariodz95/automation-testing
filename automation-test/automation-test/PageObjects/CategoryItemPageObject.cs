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
        public IWebElement cart { get; set; }


        [FindsBy(How = How.Name, Using = "priceFrom")]
        public IWebElement priceFrom { get; set; }

        [FindsBy(How = How.Name, Using = "priceTo")]
        public IWebElement priceTo { get; set; }

        [FindsBy(How = How.Id, Using = "brand_id")]
        public IWebElement brandSelector { get; set; }

        [FindsBy(How = How.Name, Using = "8892-878")]
        public IWebElement procBrand { get; set; }

 


        public CartPageObject AddToBasket()
        {
            buyButton.Clicks();
            incrementButton.Clicks();
            cart.Clicks();
            return new CartPageObject();
        }  

        public void Filtering(string priceFromValue, string priceToValue, string brand, string proc)
        {
            priceFrom.EnterText(priceFromValue);
            priceTo.EnterText(priceToValue);
            brandSelector.SelectDropDown(brand);
            procBrand.SelectDropDown(proc);
        }


    }

}
