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
            string Product_Added_Text = ReadConfig.testData["LayerCartTestData:product_added_text"];
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
            
            string Search_lable_txt = "Search ";
            string Product_item_for_search = ReadConfig.testData["SearchTestData:search_txt"];
            Driver.Navigate().GoToUrl(SiteURL);

            Assert.IsTrue(homepage.IsAtPage(), "Home Page Not Displayd or have wrong URL");

            homepage.SearchForItem(Product_item_for_search);

            Assert.IsTrue(searchResultsPage.IsAtPage(), "Serach Results not dispalyd or not visible.");
            string First_product_item_name = searchResultsPage.GetFirstProductName();

            Assert.IsTrue(First_product_item_name.Equals(Product_item_for_search, StringComparison.OrdinalIgnoreCase), "Serched First Result Item Name is different from Serched Text.");

            string Search_lable_and_search_text_from_page = searchResultsPage.GetSearchedText();

            Assert.IsTrue(Search_lable_and_search_text_from_page.Equals(Search_lable_txt + Product_item_for_search, StringComparison.OrdinalIgnoreCase), "Search output Text is different from Searched text.");

            
        }

        [Test, Description("Send a message to customer services.")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureFeature("Send_Message")]
        public void T03_Send_Message_To_Customer_Service()
        {
            string Subject = ReadConfig.testData["CustomerServiceTestData:subject"];
            string Message = ReadConfig.testData["CustomerServiceTestData:message"];
            string Email = ReadConfig.testData["CustomerServiceTestData:email"];
            string Allert_Success_message = ReadConfig.testData["CustomerServiceTestData:allet_success_message"];
            Driver.Navigate().GoToUrl(SiteURL);

            Assert.IsTrue(homepage.IsAtPage(), "Home Page Not Displayd or have wrong URL");

            homepage.ClickOnCustomreSupport_ContactUs();

            Assert.IsTrue(customerServicePage.IsAtPage(), "Customer Service Send Message Page not displayd or is not visible");
            customerServicePage.Select_Subject_Contact(Subject).
                                Add_Email(Email).
                                Add_Message(Message).
                                Send_Message();

            Assert.IsTrue(customerServicePage.Verify_Allert_Success_message(Allert_Success_message), "Allert Success message not displayd or incorrect.");
        }

    }
}
