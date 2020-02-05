using automation;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Tests
{
    [TestFixture("Chrome")]
    [TestFixture("Firefox")]
    [TestFixture("IE")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Tests : Browsers
    {
        HomePageObject main;
        CategoryItemPageObject categoryItem;
        public Tests(string browser) : base(browser) { }

        [OneTimeSetUp]
        public void Setup()
        {
            PropertiesCollection.driver.Navigate().GoToUrl(PropertiesCollection.baseUrl);
            PropertiesCollection.driver.Manage().Window.Maximize();
            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        [Test, Order(1)]
        public void Login()
        {
            LoginPageObject pageLogin = new LoginPageObject();
            main = pageLogin.Login(PropertiesCollection.Username, PropertiesCollection.Password);
        }

        [Test]
        public void SearchBoxAndCategorySelectTest()
        {
            main.SearchItem("Lenovo");
            main.SelectCategoryDropDown("GAMING");
        }

        [Test]
        public void AddToBasketTest()
        {
            HomePageObject mainObject = new HomePageObject();
            categoryItem = mainObject.AddItemToBasket();
            categoryItem.AddToBasket();
        }

        [Test]
        public void PaymentTest()
        {
            CartPageObject cart = new CartPageObject();
            cart.Pay("testiranje paymant-a");
        }

        [Test]
        public void AddToWishListTest()
        {
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            PropertiesCollection.driver.Close();
        }
    }


}