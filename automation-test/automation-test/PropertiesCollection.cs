using OpenQA.Selenium;


namespace automation
{
    public class PropertiesCollection
    {
        public static IWebDriver driver { get; set; }
        public static string baseUrl { get; set; }= "https://www.hgshop.hr/";
        public static string Username { get; set; } = "d1989948@urhen.com";
        public static string Password { get; set; } = "test123";
        public static string SearchBox { get; set; } = "LENOVO";
        public static string Dropdown { get; set; } = "GAMING";
        public static string PriceFrom { get; set; } = "4000";
        public static string PriceTo { get; set; } = "10000";
        public static string Processor { get; set; } = "Intel";
    }
}
