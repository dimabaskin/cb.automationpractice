using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cb.automationpractice.pages.Helper;
using System.Threading.Tasks;

namespace cb.automationpractice.pages.PageCode
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            WaitForElementToBeVisible(Utils.pageElements["HomePage:elements_xpath:product_list"]);
        }

        internal  IWebElement ProductFrameEl => driver.FindElement(By.XPath(Utils.pageElements["HomePage:elements_xpath:product_list"]));
        internal IList<IWebElement> ProductsListEl => driver.FindElements(By.XPath(Utils.pageElements["HomePage:elements_xpath:product_container"]));

        internal string add_to_cart_button_xpath_locator = Utils.pageElements["HomePage:elements_xpath:product_button_Add_to_cart"];
        internal string product_name_xpath_locator = Utils.pageElements["HomePage:elements_xpath:pruduct_name"];
        internal string search_top_form_xpath_locator = Utils.pageElements["HomePage:elements_xpath:search_query_form"];
        internal string search_button_submit_xpath_locator = Utils.pageElements["HomePage:elements_xpath:search_button_submit"];
        internal string contact_us_support_link_xpath_locator = Utils.pageElements["HomePage:elements_xpath:contact_us_support_link"];




        //search_query_form
        public bool IsAtPage()
        {
            string ExpectedURL = (Utils.pageElements["HomePage:HomePageURL"]);

            return driver.Url == ExpectedURL && ProductFrameEl.Displayed;

        }

        public string GetFirstProductName()
        {
            var ProductList = ProductsListEl;
            var FirstItem = ProductList.FirstOrDefault();
            return FirstItem.FindElement(By.XPath(product_name_xpath_locator)).Text;
        }

        public void AddFirstItemToCart()
        {
            var ProductList = ProductsListEl;
            var FirstItem = ProductList.FirstOrDefault();

            MoveToElemnt(FirstItem);


            FirstItem.FindElement(By.XPath(add_to_cart_button_xpath_locator)).Click();

        }

        public void SearchForItem(string search_txt)
        {
            FillText(driver.FindElement(By.XPath(search_top_form_xpath_locator)), search_txt);
            Click(driver.FindElement(By.XPath(search_button_submit_xpath_locator)));
        }

        public void ClickOnCustomreSupport_ContactUs()
        {
            Click(driver.FindElement(By.XPath(contact_us_support_link_xpath_locator)));
        }
    }
}
