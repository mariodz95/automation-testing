using OpenQA.Selenium;
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

        [FindsBy(How = How.LinkText, Using = "RAČUNALA")]
        public IWebElement pc { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[contains(text(),'Prijenosna računala')])[5]")]
        public IWebElement laptops { get; set; }


        public void AddItemToBasket()
        {
            itEquipment.Clicks();
            categoryItem.Clicks();
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

        public void GoToSmartphones() {
            pc.Clicks();
            laptops.Clicks();
        }
    }
}
