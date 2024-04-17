using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProj
{
    internal class TestBase
    {
        protected IWebDriver driver;
        protected VeeamPage veeamPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            veeamPage = new VeeamPage(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://careers.veeam.com/vacancies");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

    }
}

