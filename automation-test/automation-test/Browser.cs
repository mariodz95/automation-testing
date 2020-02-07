using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace automation
{
    [SetUpFixture]
    public class Browsers
    {
        protected string browser;

        public Browsers()
        {
        }

        public Browsers(string browser)
        {
            this.browser = browser;
        }

        [OneTimeSetUp]
        public void Init()
        {
            switch (browser)
            {
                case "Chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    PropertiesCollection.driver = new ChromeDriver();
                    break;
                case "Firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    PropertiesCollection.driver = new FirefoxDriver();
                    break;
                case "Edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    PropertiesCollection.driver = new EdgeDriver(".");
                    break;
            }
            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }



        [OneTimeTearDown]
        public void Cleanup()
        {
            PropertiesCollection.driver.Quit();
        }
    }
}
