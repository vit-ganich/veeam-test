using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using VeeamTest.Base;
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

            WaitFor(Element.Click);

            IWebElement checkBox;
            if (!Page.Driver.GetType().Name.Contains("Firefox"))
            { 
                checkBox = GetCheckBoxJS(value);
            }
            else
            {
                string index = GetIndexByLabel(value);
                string checkBoxLocator = string.Format("#ch-{0} + span", index);
                checkBox = GetChildElement(By.CssSelector(checkBoxLocator));
            }
            WaitFor(checkBox.Click, timeoutSec: 15);
            WaitFor(Apply.Click);

            return this;
        }

        /// <summary>
        /// Not works for Firefox (maybe, FirefoxDriver bug)
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public IWebElement GetCheckBoxJS(string label)
        {
            string script = "return $(\"label:contains('English')\")";
            IJavaScriptExecutor js = Page.Driver as IJavaScriptExecutor;
            try
            {
                var elem = js.ExecuteScript(script, label) as IReadOnlyCollection<IWebElement>;
                return elem.ElementAt(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        /// <summary>
        /// Very ugly solution, but I didn't have enough time to solve it more efficient. Sorry :-)
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public string GetIndexByLabel(string label)
        {
            switch (label)
            {
                case "English":
                    return "7";
                case "Czech":
                    return "4";
                case "Dutch":
                    return "6";
                case "Russian":
                    return "22";
                case "Spanish":
                    return "24";
                case "German":
                    return "11";
                default:
                    return "0";
            }
        }

    }
}
