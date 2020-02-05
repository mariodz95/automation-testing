﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Tests;

namespace automation
{
    public class HomePageObject 
    {
        public HomePageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement searchBox { get; set; }

        [FindsBy(How = How.ClassName, Using = "submit")]
        public IWebElement submit { get; set; }

        [FindsBy(How = How.ClassName, Using = "category")]
        public IWebElement category { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href='/profile.aspx']")]
        public IWebElement searchButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "IT OPREMA")]
        public IWebElement itEquipment { get; set; }
        
        [FindsBy(How = How.XPath, Using = "(//a[contains(text(),'Kabeli')])[12]")]
        public IWebElement categoryItem { get; set; }

        public CategoryItemPageObject AddItemToBasket()
        {
            itEquipment.Clicks();
            categoryItem.Clicks();
            return new CategoryItemPageObject();
        }

        public void SearchItem(string inputData)
        {
           searchBox.EnterText(inputData);
        }

        public void SelectCategoryDropDown(string item)
        {
            category.SelectDropDown(item);
            searchButton.Click();
        }


    }
}