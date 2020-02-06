using automation;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Status = AventStack.ExtentReports.Status;

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
        ReportsGenerationClass report;

        public AventStack.ExtentReports.ExtentReports _extent;
        protected ExtentTest _test;
        public Tests(string browser) : base(browser) { }

        [OneTimeSetUp]
        public void Setup()
         {
            PropertiesCollection.driver.Navigate().GoToUrl(PropertiesCollection.baseUrl);
            PropertiesCollection.driver.Manage().Window.Maximize();

            report = new ReportsGenerationClass();


            var dir = TestContext.CurrentContext.TestDirectory + "\\";
            var fileName = this.GetType().ToString() + ".html";
            var htmlReporter = new ExtentHtmlReporter("extent.html");

            _extent = new AventStack.ExtentReports.ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [Test, Order(1)]
        public void Login()
        {
            _test = report.BeforeTest(_extent);

            LoginPageObject pageLogin = new LoginPageObject();
            main = pageLogin.Login(PropertiesCollection.Username, PropertiesCollection.Password);
            report.PassOrFailed(_test);
        }

        [Test]
        public void SearchBoxAndCategorySelectTest()
        {
            _test = report.BeforeTest(_extent);

            main.SearchItem("Lenovo");
            main.SelectCategoryDropDown("GAMING");

            report.PassOrFailed(_test);

        }

        [Test]
        public void AddToBasketTest()
        {
            _test = report.BeforeTest(_extent);

            HomePageObject mainObject = new HomePageObject();
            categoryItem = mainObject.AddItemToBasket();
            categoryItem.AddToBasket();

            report.PassOrFailed(_test);

        }

        [Test]
        public void PaymentTest()
        {
            _test = report.BeforeTest(_extent);

            CartPageObject cart = new CartPageObject();
            cart.Pay("testiranje paymant-a");

            report.PassOrFailed(_test);
        }


        //[Test]
        //public void AddToWishListTest()
        //{
        //}

         [TearDown]
         public void InsertReport()
         {
            report.AfterTest(_extent, _test);
         }

        [OneTimeTearDown]
        public void EndTest()
        {
            PropertiesCollection.driver.Close();
            _extent.Flush();
        }
    }
}