using OpenQA.Selenium;
using VeeamTest.Controls.IActions;

namespace VeeamTest.Controls
{
    public class TextField : BaseControl, IReadable
    {
        public TextField(By locator, IPage testPage) : base(locator, testPage) { }

        public string Read()
        {
            return Element.GetAttribute("innerText");
        }

        public IReadable Read(out string text)
        {
            text = Read();
            return this;
        }
    }
}
