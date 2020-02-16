using OpenQA.Selenium;
using VeeamTest.Controls.IActions;

namespace VeeamTest.Controls
{
    public class DropDownCheckList : DropDownList
    {
        private IWebElement Apply => GetChildElement(By.ClassName("selecter-fieldset-submit"));
        public DropDownCheckList(By locator, IPage testPage) : base(locator, testPage) { }

        public override ISelectable Select(string value)
        {
            if (value == "blank")
                return this;

            base.ActivateDropDown();

            string checkBoxLocator = string.Format("#ch-{0} + span", value);
            var checkBox = GetChildElement(By.CssSelector(checkBoxLocator));

            WaitFor(checkBox.Click, timeoutSec: 15);
            WaitFor(Apply.Click);

            return this;
        }

        
    }
}
