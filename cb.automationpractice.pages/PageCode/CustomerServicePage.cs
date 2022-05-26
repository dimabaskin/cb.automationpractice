using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cb.automationpractice.pages.Helper;
using System.Threading.Tasks;

namespace cb.automationpractice.pages.PageCode
{
    public class CustomerServicePage : BasePage
    {
        public CustomerServicePage(IWebDriver driver) : base(driver)
        {
        }

        internal string contact_form_xpath_locator = Utils.pageElements["CustomerService:elements_xpath:contact_form"];
        internal string select_contact_xpath_locator = Utils.pageElements["CustomerService:elements_xpath:select_contact_drpdow_list"];
        internal string email_input_xpath_locator = Utils.pageElements["CustomerService:elements_xpath:email_input"];
        internal string message_input_txt_xpath_locator = Utils.pageElements["CustomerService:elements_xpath:message_input_txt"];
        internal string send_submit_btn_xpath_locator = Utils.pageElements["CustomerService:elements_xpath:send_submit_btn"];
        internal string allert_success_message_xpath_locator = Utils.pageElements["CustomerService:elements_xpath:allert_success_message"];
        internal string allert_error_message_xpath_locator = Utils.pageElements["CustomerService:elements_xpath:allert_error_message"];


        public bool IsAtPage()
        {
            WaitForElementToBeVisible(contact_form_xpath_locator);
            
            return IsDisplayed(driver.FindElement(By.XPath(contact_form_xpath_locator)));

        }

        public CustomerServicePage Select_Subject_Contact(string subject_name)
        {
            SelectItemByText(driver.FindElement(By.XPath(select_contact_xpath_locator)), subject_name);
            return this;

        }

        public CustomerServicePage Add_Email(string email)
        {
            FillText(driver.FindElement(By.XPath(email_input_xpath_locator)), email);
            return this;
        }

        public CustomerServicePage Add_Message(string message_text)
        {
            FillText(driver.FindElement(By.XPath(message_input_txt_xpath_locator)), message_text);
            return this;
        }

        public CustomerServicePage Send_Message()
        {
            Click(driver.FindElement(By.XPath(send_submit_btn_xpath_locator)));
            return this;
        }

        public bool Verify_Allert_Success_message(string message)
        {
            WaitForElementToBeVisible(allert_success_message_xpath_locator);
            
            return IsDisplayed(driver.FindElement(By.XPath(allert_success_message_xpath_locator))) &&
                    driver.FindElement(By.XPath(allert_success_message_xpath_locator)).Text.Equals(message, StringComparison.OrdinalIgnoreCase);

        }



    }
}
