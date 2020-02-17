using OpenQA.Selenium;
using System;
using VeeamTest.Controls.IActions;

namespace VeeamTest.Base
{
    public abstract class BasePage : IPage
    {
        public IWebDriver Driver { get; set; }

        public abstract IPage Load();

        public IPage Click(IClickable control)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            control.Click();
            return this;
        }

        public IPage Select(ISelectable control, string value)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            control.Select(value);
            return this;
        }

        public IPage Read(IReadable control, out string text)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            control.Read(out text);
            return this;
        }
    }
}
