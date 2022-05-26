using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cb.automationpractice.pages.Helper;
using System.Threading.Tasks;

namespace cb.automationpractice.pages.PageCode
{
    public  class LayerCartPage : BasePage
    {
        public LayerCartPage(IWebDriver driver) : base(driver)
        {
            
        }

        string layer_cart_frame_xpath_locator = Utils.pageElements["LayerCartPage:elements_xpath:layer_cart_frame"];
        string layer_cart_ok_icon_locator = Utils.pageElements["LayerCartPage:elements_xpath:ok_icon"];
        string layer_cart_product_text_locator = Utils.pageElements["LayerCartPage:elements_xpath:layer_cart_product_text"];
        string layer_cart_product_title = Utils.pageElements["LayerCartPage:elements_xpath:cart_product_title"];
        string layer_cart_product_count_txt_locator = Utils.pageElements["LayerCartPage:elements_xpath:cart_product_quantity_txt"];

        public bool IsAtPage()
        {
            WaitForElementToBeVisible(Utils.pageElements["LayerCartPage:elements_xpath:layer_cart_frame"]);
            return driver.FindElement(By.XPath(layer_cart_frame_xpath_locator)).Displayed;
             
        }

        public bool IsProductIconOK()
        {
            return driver.FindElement(By.XPath(layer_cart_ok_icon_locator)).Displayed;
        }

        public bool VerifyAddProductText(string TextMessage)
        {
            return driver.FindElement(By.XPath(layer_cart_product_text_locator)).Text.Equals(TextMessage, StringComparison.OrdinalIgnoreCase);
        }

        public bool VerifyProductName(string ProductName)
        {
            return driver.FindElement(By.XPath(layer_cart_product_title)).Text.Equals(ProductName, StringComparison.OrdinalIgnoreCase);
        }

        public bool VerifyProductCount(int ProductCount)
        {
            var items = new List<string>(
                driver.FindElement(By.XPath(layer_cart_product_count_txt_locator)).Text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries));

            var item = items[2];

            return Convert.ToInt32(item) == ProductCount;
        }

    }
}
