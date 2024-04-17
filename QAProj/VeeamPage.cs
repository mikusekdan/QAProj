using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProj
{
    public class VeeamPage
    {
        private IWebDriver _driver;

        IWebElement _searchTextBox => _driver.FindElement(By.XPath("//input[@type= 'search']"));

        IWebElement _searchButton => _driver.FindElement(By.Id("nav-search-submit-button"));

        IWebElement _selectCountryCombo => _driver.FindElement(By.XPath("//div[@class = 'form-group d-md-flex']/div[@class = 'dropdown']/div[@class = 'dropdown']/button"));
        //"//div[@class = 'form-group d-md-flex']/div[@class = 'dropdown']/div[@class = 'dropdown']/button"));

        IWebElement _selectCityCombo => _driver.FindElement(By.XPath("//button[@Id = 'city-toggler' and text() = 'All cities']"));

        IWebElement _findButton => _driver.FindElement(By.XPath("//button[@class = 'btn btn-outline-success']"));

        IWebElement _selectStateCombo => _driver.FindElement(By.XPath("//div[@class = 'form-group d-md-flex']//button[text() = 'All states']"));


        public VeeamPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Search(string searchTech)
        {
            _searchTextBox.Click();
            _searchTextBox.SendKeys(searchTech);

        }

        public void AssertNumberOfSalesCards(int expectedNumber)
        {
            WaitForElement(30, null, "//div[@class = 'row d-none d-md-block']//div[@class = 'd-none d-lg-block']//a[@class = 'card card-md-45 card-no-hover card--shadowed']");

            int actualNumber = _driver.FindElements(By.XPath("//div[@class = 'row d-none d-md-block']//div[@class = 'd-none d-lg-block']//a[@class = 'card card-md-45 card-no-hover card--shadowed']")).Count;
            Assert.AreEqual(expectedNumber, actualNumber);

        }

        public void SelectCountryFromSelectBoxByName(string countryName)
        {
            _selectCountryCombo.Click();

            var element = _driver.FindElement(By.XPath("//div[@x-placement = 'bottom-start']/div[@class = 'scrollarea area']/div[@class = 'scrollarea-content content']/a[text() = '" + countryName + "']"));
            Actions actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();

            _driver.FindElement(By.XPath("//a[@class = 'dropdown-item' and text() = '" + countryName + "']")).Click();
        }

        public void SelectStateFromSelectBoxByName(string stateName)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 200)", "");

            _selectStateCombo.Click();

            var element = _driver.FindElement(By.XPath("//div[@x-placement = 'bottom-start']/div[@class = 'scrollarea area']/div[@class = 'scrollarea-content content']/a[text() = '" + stateName + "']"));
            Actions actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();

            _driver.FindElement(By.XPath("//a[@class = 'dropdown-item' and text() = '" + stateName + "']")).Click();
        }

        public void SelectCityFromSelectBoxByName(string cityName)
        {
            _selectCityCombo.Click();
            _driver.FindElement(By.XPath("//a[@class = 'dropdown-item' and text() = '" + cityName + "']")).Click();
        }

        public void ClickOnFindButton()
        {
            _findButton.Click();
        }

        public void WaitForElement(int seconds, IWebElement element = null, string elementXPath = null)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            if (elementXPath == null)
            {
                wait.Until(driver => element.Displayed);
            }
            else
            {
                wait.Until(driver => driver.FindElement(By.XPath($"{elementXPath}")).Displayed);//.Count >= 2);
            }
        }

    }
}
