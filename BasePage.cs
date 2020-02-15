using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using VeeamTest.Helpers;

namespace VeeamTest
{
    public class BasePage
    {
        IWebDriver driver;
        public BasePage()
        {
            this.driver = WebDriver.Driver;
            Load();
        }
        
        private const string PageUrl = "https://careers.veeam.com/";

        public By CountriesDropDown => By.Id("country-element");

        public By CitiesDropDown => By.Id("city-element");

        public By DepartementsDropDown => By.Id("department-element");

        public By LanguagesDropDown => By.Id("language");

        private By LanguagesDropDownApply = By.ClassName("selecter-fieldset-submit");

        public By JobSearchResults = By.CssSelector(".vacancies-blocks .text-center-md-down");

        public BasePage Load()
        {
            driver.Navigate().GoToUrl(PageUrl);
            _ = GenericHelper.GetElement(By.CssSelector(".navbar-brand img"));
            return this;
        }

        public BasePage SelectItemByText(By locator, string textToSelect)
        {
            if (textToSelect == "blank")
                return this;

            var dropDown = ActivateDropDown(locator);
            By itemLocator = By.XPath(string.Format("//span[contains(text(), '{0}')]", textToSelect));
            SelectItemInDropDown(dropDown, itemLocator);
            
            return this;
        }

        public BasePage SelectCheckBoxById(By locator, string idToSelect)
        {
            if (idToSelect == "blank")
                return this;

            var dropDown = ActivateDropDown(locator);
            By checkBoxLocator = By.CssSelector(string.Format("#ch-{0} + span", idToSelect));
            SelectItemInDropDown(dropDown, checkBoxLocator);
            var applyBtn = GenericHelper.GetElement(LanguagesDropDownApply);
            WaitHelper.WaitFor(applyBtn.Click);
            return this;
        }

        public IWebElement ActivateDropDown(By locator)
        {
            var dropDown = GenericHelper.GetElement(locator);
            JSExecHelper.ScrollElementIntoView(dropDown);
            WaitHelper.WaitFor(dropDown.Click);
            return dropDown;
        }

        public void SelectItemInDropDown(IWebElement dropDown, By itemLocator)
        {
            var itemToSelect = GenericHelper.GetChildElement(dropDown, itemLocator);
            WaitHelper.WaitFor(itemToSelect.Click, timeoutSec: 15);
        }

        public BasePage GetJobSearchResult(out string result)
        {
            var elem = GenericHelper.GetElement(JobSearchResults);
            result = elem.GetAttribute("innerText");
            return this;
        }

    }
}
