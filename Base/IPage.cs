using OpenQA.Selenium;
using VeeamTest.Controls.IActions;

namespace VeeamTest.Base
{
    public interface IPage
    {
        IWebDriver Driver { get; set; }
        IPage Load();

        #region IClickableControls
        IPage Click(IClickable control);
        #endregion

        #region ISelectableControls
        IPage Select(ISelectable control, string value);
        #endregion

        #region IReadableControls

        IPage Read(IReadable control, out string text);
        #endregion
    }
}
