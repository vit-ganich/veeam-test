using OpenQA.Selenium;
using VeeamTest.Base;
using VeeamTest.Controls.IActions;
using VeeamTest.Controls.IControls;

namespace VeeamTest.Controls
{
    public class Button : BaseControl, IButton
    {
        public Button(By locator, IPage testPage) : base(locator, testPage) { }

        public IClickable Click()
        {
            Element.Click();
            System.Threading.Thread.Sleep(500); // for IE
            return this;
        }
    }
}
