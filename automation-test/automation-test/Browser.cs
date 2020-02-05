using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace automation
{
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
                case "IE":
                    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                    PropertiesCollection.driver = new InternetExplorerDriver();
                    break;
            }
        }
    }
}
