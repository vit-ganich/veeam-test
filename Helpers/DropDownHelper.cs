using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VeeamTest.Helpers
{
    public class DropDownHelper
    {
        private static SelectElement select;

        public static void SelectElement(By locator, int index)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            select.SelectByIndex(index);
            Console.WriteLine("Selected index : {0}", select.SelectedOption.Text);
        }

        public static void SelectElement(By locator, string text)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));

            select.SelectByText(text);
        }

        public static void SelectElement(IWebElement element, string text)
        {
            select = new SelectElement(element);

            select.SelectByText(text);
        }
    }
}