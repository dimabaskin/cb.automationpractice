using OpenQA.Selenium;
using System.Configuration;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using NUnit.Framework.Interfaces;
using System.Net.Mime;
using Allure.Commons;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using cb.automationpractice.pages.Helper;
using cb.automationpractice.pages.PageCode;

//using WebDriverManager;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using Microsoft.Extensions.Configuration;

//using WebDriverManager.DriverConfigs.Impl;



namespace cb.automationpractice.uitest.Tests
{
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }

        public HomePage homepage;
        public LayerCartPage layerCartPage;
        public SearchResultsPage searchResultsPage;
        public CustomerServicePage customerServicePage;
        public string SiteURL = ReadConfig.appConfig["SiteURL"];


        [OneTimeSetUp]
        public void Setup()
        {


            // browser selection
            // checking if browser type is received from command line: if not then fall back from config file
            var browserType = ReadConfig.appConfig["browserType"];
            var PageLoadTimeout = Convert.ToInt32(ReadConfig.appConfig["PageLoadTimeout"]);
            
            switch (browserType)
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    Driver = new ChromeDriver();
                    break;
                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    Driver = new EdgeDriver();
                    break;
                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    Driver = new FirefoxDriver();
                    break;
                default:
                    throw new NotSupportedException($"No such browser {browserType}");
            }
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(PageLoadTimeout);
            Driver.Navigate().GoToUrl(SiteURL);
            //string ExpectedUrl = Utils.pageElements["loginPage:LoginPageURL"];
            //Assert.That(Driver.Url, Is.EqualTo(ExpectedUrl), "did not get to the expected url");


            homepage = new HomePage(Driver);
            layerCartPage = new LayerCartPage(Driver);
            searchResultsPage = new SearchResultsPage(Driver);
            customerServicePage = new CustomerServicePage(Driver);
        }

        public IWebDriver? GetDriver()
        {
            return Driver;
        }

        [TearDown]
        public void TakeScreenShotOnFailure()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                AllureLifecycle.Instance.AddAttachment("Full page screenshot", MediaTypeNames.Image.Jpeg, ((ITakesScreenshot)Driver).GetScreenshot().AsByteArray);
            }
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            Driver.Quit();
        }

    }
}
