using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Allure.Commons;
using cb.automationpractice.pages.Helper;
using OpenQA.Selenium;

namespace cb.automationpractice.uitest.Tests
{
    [AllureNUnit]
    [AllureEpic("Login Page")]
    [Parallelizable]
    public class HomePageTest : BaseTest
    {
        
        [Test, Description("Add a new item to the cart and it navigates to 'Shopping-cart summary'.")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureFeature("add_item")]
        public void T01_Add_Item_to_cart()
        {
            string Product_Added_Text = ReadConfig.testData["LayerCartPage:product_added_text"];
            string Product_Name;
            Assert.IsTrue(homepage.IsAtPage(), "Home Page Not Displayd or have wrong URL");
            Product_Name = homepage.GetFirstProductName();
            homepage.AddFirstItemToCart();

            Assert.IsTrue(layerCartPage.IsAtPage(), "Cart layer popup not displayd or not visible. ");
            Assert.IsTrue(layerCartPage.IsProductIconOK(), "Incorrect Icon");
            Assert.IsTrue(layerCartPage.VerifyAddProductText(Product_Added_Text), "Incorrect Message after adding Product to Cart.");
            Assert.IsTrue(layerCartPage.VerifyProductCount(1), "Incorrect Product Quantity.");
            Assert.IsTrue(layerCartPage.VerifyProductName(Product_Name), "Incorrect Product Name.");


        }

        [Test, Description("Search for the Item.")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureFeature("search_item")]
        public void T02_Search_for_Item()
        {
            //todo
            //o.	Search for “Printed Chiffon Dress”
            //q.	Assert that it is the first result in the list
            //r.	Assert text “Search  "Printed Chiffon Dress" appears
        }

    }
}
