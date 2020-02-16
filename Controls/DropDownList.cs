using OpenQA.Selenium;
using VeeamTest.Controls.IActions;
using VeeamTest.Controls.IControls;
using VeeamTest.Helpers;

namespace VeeamTest.Controls
{
    public class DropDownList : BaseControl, IDropDownLIst
    {
        public DropDownList(By locator, IPage testPage) : base(locator, testPage) { }

        public virtual ISelectable Select(string value)
        {
            if (value == "blank")
                return this;

            ActivateDropDown();

            string itemLocator = string.Format("//span[contains(text(), '{0}')]", value);
            var itemToSelect = GetChildElement(By.XPath(itemLocator));

            WaitFor(itemToSelect.Click, timeoutSec: 15);
            return this;
        }

        protected void ActivateDropDown()
        {
            JSExecHelper.ScrollElementIntoView(Page.Driver, Element);
            WaitFor(Element.Click);
        }

    }
}
