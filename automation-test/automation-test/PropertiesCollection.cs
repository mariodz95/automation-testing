﻿using OpenQA.Selenium;


namespace automation
{
    public class PropertiesCollection
    {
        public static IWebDriver driver { get; set; }
        public static string baseUrl { get; set; }= "https://www.hgshop.hr/";
        public static string Username { get; set; } = "";
        public static string Password { get; set; } = "test123";
    }
}
