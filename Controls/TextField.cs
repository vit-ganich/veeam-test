using OpenQA.Selenium;
using VeeamTest.Base;
using VeeamTest.Controls.IActions;

namespace VeeamTest.Controls
{
    public class TextField : BaseControl, IReadable
    {
        public TextField(By locator, IPage testPage) : base(locator, testPage) { }

        public string Read()
        {
            return GetAttribute("innerText");
        }

        public IReadable Read(out string text)
        {
            System.Threading.Thread.Sleep(1000);
            text = Read();
            return this;
        }
    }
}
