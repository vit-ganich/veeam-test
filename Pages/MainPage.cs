using OpenQA.Selenium;
using VeeamTest.Controls;

namespace VeeamTest.Pages
{
    public class MainPage : BasePage
    {
        private const string PageUrl = "https://careers.veeam.com/";

        public DropDownList CountriesList => new DropDownList(By.Id("country-element"), this);
        public DropDownList CitiesList => new DropDownList(By.Id("city-element"), this);
        public DropDownList DepartementsList => new DropDownList(By.Id("department-element"), this);
        public DropDownCheckList LanguagesList => new DropDownCheckList(By.Id("language"), this);
        public TextField JobSearchResults => new TextField(By.CssSelector(".vacancies-blocks .text-center-md-down"), this);

        public override IPage Load()
        {
            this.Driver.Navigate().GoToUrl(PageUrl);
            return this;
        }

        //public MainPage SelectItemByText(By locator, string textToSelect)
        //{
        //    if (textToSelect == "blank")
        //        return this;

        //    var dropDown = ActivateDropDown(locator);
        //    By itemLocator = By.XPath(string.Format("//span[contains(text(), '{0}')]", textToSelect));
        //    SelectItemInDropDown(dropDown, itemLocator);
            
        //    return this;
        //}



        //public IWebElement ActivateDropDown(By locator)
        //{
        //    var dropDown = GenericHelper.GetElement(locator);
        //    JSExecHelper.ScrollElementIntoView(dropDown);
        //    WaitHelper.WaitFor(dropDown.Click);
        //    return dropDown;
        //}

        //public void SelectItemInDropDown(IWebElement dropDown, By itemLocator)
        //{
        //    var itemToSelect = GenericHelper.GetChildElement(dropDown, itemLocator);
        //    WaitHelper.WaitFor(itemToSelect.Click, timeoutSec: 15);
        //}

        //public MainPage GetJobSearchResult(out string result)
        //{
        //    var elem = GenericHelper.GetElement(JobSearchResults);
        //    result = elem.GetAttribute("innerText");
        //    return this;
        //}
    }
}
