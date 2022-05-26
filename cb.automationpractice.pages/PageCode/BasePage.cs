﻿using System;
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

        public IWebDriver driver { get; set; }

        public WebDriverWait wait { get; set; }

        //public IWebElement loading => driver.FindElement(By.CssSelector("#loading"));

        public Actions action { get; set; }

        public IJavaScriptExecutor js { get; set; }

        // constructor
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            action = new Actions(driver);
            js = (IJavaScriptExecutor)driver;
        }

        /* Selenium GUI Controls Operations*/

        public void FillText(IWebElement element, string text)
        {
            HightlightElement(element, "lightgreen");
            element.Clear();
            element.SendKeys(text);
        }

        public void Click(IWebElement element)
        {
            HightlightElement(element, "yellow");
            element.Click();
        }

        public string GetElementText(IWebElement element)
        {
            //HightlightElement(element, "orange");
            return element.Text;
        }

        private void HightlightElement(IWebElement el, string color)
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
        public void MoveToElemnt(IWebElement context)
        {
            action.MoveToElement(context).Perform();
        }

        /* wait methods*/

        public void Loading()
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("loading")));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#loading")));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.Id("loading")));
            //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("#loading")));
        }

        public void WaitForElementToBeVisible(string locator)
        {
            //wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locator)));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
        }

        /* Alerts */
        public void AllertSendText(string text)
        {
            driver.SwitchTo().Alert().SendKeys(text);
        }

        public void AllertAccept()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void AllertCancel()
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        // common validations

        public bool IsPageDisplayed(IWebElement el)
        {
            return el.Displayed;
        }

        public enum ButtonState
        {
            NONE,
            ADD,
            REMOVE
        }
    }
}
