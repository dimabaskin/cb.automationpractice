using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cb.automationpractice.pages.Helper;
using System.Threading.Tasks;

namespace cb.automationpractice.pages.PageCode
{
    public class SearchResultsPage : BasePage
    {
        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        internal string search_container_xpath_locator = Utils.pageElements["SearchResults:elements_xpath:search_container"];
        internal string product_list_xpath_locator = Utils.pageElements["SearchResults:elements_xpath:product_list_container"];
        internal string product_name_xpath_locator = Utils.pageElements["SearchResults:elements_xpath:product_name"];
        internal string lighter_txt_xpath_locator = Utils.pageElements["SearchResults:elements_xpath:lighter_txt"];
        //to do add locator for "Search"

        public bool IsAtPage()
        {
            WaitForElementToBeVisible(search_container_xpath_locator);
            return IsDisplayed(driver.FindElement(By.XPath(search_container_xpath_locator)));

        }

        public string GetFirstProductName()
        {
            var ProductList = driver.FindElements(By.XPath(product_list_xpath_locator));
            var FirstItem = ProductList.FirstOrDefault();
            return FirstItem.FindElement(By.XPath(product_name_xpath_locator)).Text;
        }

        public string GetSearchedText()
        {
            string Search_Result_Text = driver.FindElement(By.XPath(search_container_xpath_locator)).Text;
            string Search_Text = driver.FindElement(By.XPath(lighter_txt_xpath_locator)).Text;

            string Search_Lable = Search_Result_Text.Substring(0, Search_Result_Text.IndexOf(" ") + 1);
            Search_Text = Search_Text.Replace("\"","");

            return Search_Lable + Search_Text;
            
        }
    }
}
