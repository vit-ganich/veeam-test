using OpenQA.Selenium;
using VeeamTest.Base;
using VeeamTest.Controls;

namespace VeeamTest.Pages
{
    public class MainPage : BasePage
    {
        private const string PageUrl = "https://careers.veeam.com/";

        public DropDownList CountriesList => new DropDownList(By.CssSelector("dd#country-element"), this);
        public DropDownList CitiesList => new DropDownList(By.CssSelector("dd#city-element"), this);
        public DropDownList DepartementsList => new DropDownList(By.CssSelector("dd#department-element"), this);
        public DropDownCheckList LanguagesList => new DropDownCheckList(By.Id("language"), this);
        public TextField JobSearchResults => new TextField(By.CssSelector(".vacancies-blocks .text-center-md-down"), this);
        public Button ClearFilters => new Button(By.CssSelector("#clear-filters-button"), this);

        public override IPage Load()
        {
            this.Driver.Navigate().GoToUrl(PageUrl);
            return this;
        }
    }
}
