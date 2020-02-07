using automation;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.Threading;


namespace Tests
{
    [TestFixture("Edge")]
    [TestFixture("Chrome")]
    [TestFixture("Firefox")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Tests : Browsers
    {

        HomePageObject main;
        CategoryItemPageObject categoryItem;
        ReportsGenerationClass report;
        HomePageObject mainObject;



        public AventStack.ExtentReports.ExtentReports _extent;
        protected ExtentTest _test;
        public Tests(string browser) : base(browser) { }

        [OneTimeSetUp]
        public void Setup()
         {
            PropertiesCollection.driver.Navigate().GoToUrl(PropertiesCollection.baseUrl);
            PropertiesCollection.driver.Manage().Window.Maximize();

            report = new ReportsGenerationClass();
            mainObject = new HomePageObject();
            categoryItem = new CategoryItemPageObject();

            var htmlReporter = new ExtentV3HtmlReporter(@""+ browser + ".html");

            _extent = new AventStack.ExtentReports.ExtentReports();
            _extent.AttachReporter(htmlReporter);

            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        [Test, Order(1)]
        public void Login()
        {
            _test = report.BeforeTest(_extent);

            LoginPageObject pageLogin = new LoginPageObject();
            pageLogin.Login(PropertiesCollection.Username, PropertiesCollection.Password);
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

            mainObject.AddItemToBasket();
            categoryItem.AddToBasket();

            report.PassOrFailed(_test);

        }

        [Test]
        public void PaymentTest()
        {
            _test = report.BeforeTest(_extent);

            CartPageObject cart = new CartPageObject();
            cart.Pay("testiranje paymant-a");
            cart.clickFinish();
            report.PassOrFailed(_test);
        }


        [Test]
        public void SearchAndFilter()
        {
            _test = report.BeforeTest(_extent);

            mainObject.GoToSmartphones();
            categoryItem.Filtering(PropertiesCollection.PriceFrom, PropertiesCollection.PriceTo, PropertiesCollection.SearchBox, PropertiesCollection.Processor);

            report.PassOrFailed(_test);
        }

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