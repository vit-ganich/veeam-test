using OpenQA.Selenium;
using VeeamTest.Base;
using VeeamTest.Controls.IActions;
using VeeamTest.Controls.IControls;

namespace VeeamTest.Controls
{
    public class DropDownList : BaseControl, IDropDownLIst
    {
        public DropDownList(By locator, IPage testPage) : base(locator, testPage) { }

        public virtual ISelectable Select(string value)
        {
            if (value == "blank")
                return this;

            ExecuteJavaScript("arguments[0].scrollIntoView(true);");
            WaitFor(Element.Click);

            string itemLocator = string.Format("//span[contains(text(), '{0}')]", value);
            var itemToSelect = GetChildElement(By.XPath(itemLocator));

            WaitFor(itemToSelect.Click);
            return this;
        }
    }
}
