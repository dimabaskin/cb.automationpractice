using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;




namespace cb.automationpractice.pages.PageCode
{
    public class BasePage
    {

        internal IWebDriver driver { get; set; }

        internal WebDriverWait wait { get; set; }

        internal Actions action { get; set; }

        internal IJavaScriptExecutor js { get; set; }

        // constructor
        internal BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            action = new Actions(driver);
            js = (IJavaScriptExecutor)driver;
        }

        /* Selenium GUI Controls Operations*/

        internal void FillText(IWebElement element, string text)
        {
            HightlightElement(element, "lightgreen");
            element.Clear();
            element.SendKeys(text);
        }

        internal void Click(IWebElement element)
        {
            HightlightElement(element, "yellow");
            element.Click();
        }

        internal void SelectItemByText(IWebElement element,string value)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(value);
        }

        public void SelectItemByValue(IWebElement element, string value)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }

        internal string GetElementText(IWebElement element)
        {
            //HightlightElement(element, "orange");
            return element.Text;
        }

        internal void HightlightElement(IWebElement el, string color)
        {
            // getting the current style in order to change back
            String originalStyle = el.GetAttribute("style");

            // creating a new style based on the input color
            String newStyle = "background-color:" + color + ";border: 1px solid;" + originalStyle;

            // changing the style
            js.ExecuteScript("var tmpArguments = arguments;setTimeout(function () {tmpArguments[0].setAttribute('style', '" + newStyle + "');},0);",
                    el);

            // change back the style after a few miliseconds
            js.ExecuteScript("var tmpArguments = arguments;setTimeout(function () {tmpArguments[0].setAttribute('style', '" + originalStyle + "');},400);",
                    el);
        }


        // mouse roll over function
        internal void MoveToElemnt(IWebElement context)
        {
            action.MoveToElement(context).Perform();
        }

        internal void WaitForElementToBeVisible(string locator)
        {
            //wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locator)));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
        }

        /* Alerts */
        internal void AllertSendText(string text)
        {
            driver.SwitchTo().Alert().SendKeys(text);
        }

        internal void AllertAccept()
        {
            driver.SwitchTo().Alert().Accept();
        }

        internal void AllertCancel()
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        // common validations

        internal bool IsDisplayed(IWebElement el)
        {
            return el.Displayed;
        }

    }
}
