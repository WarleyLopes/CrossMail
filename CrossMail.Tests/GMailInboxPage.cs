using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.IO;

namespace CrossMail.Tests
{
    public class GMailInboxPage
    {
        private IWebDriver driver;
        public GMailInboxPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@role='button' and (.)='COMPOSE']")]
        private IWebElement composeElement;

        [FindsBy(How = How.Name, Using = "to")]
        private IWebElement destinationInput;

        [FindsBy(How = How.XPath, Using = "//*[@role='button' and text()='Send']")]
        private IWebElement sendButtonElement;

        [FindsBy(How = How.XPath, Using = "//input[@name='subjectbox']")]
        private IWebElement subjectBoxElement;

        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Message Body']")]
        private IWebElement bodyTextBoxElement;

        [FindsBy(How = How.XPath, Using = "//input[@name='Filedata']")]
        private IWebElement attachFileElement;

        public void SendMail(string destination, string subject, string bodyText, string attachment = "")
        {
            //Needs improvement because of user locale while running the webdriver
            composeElement.Click();
            destinationInput.Clear();
            destinationInput.SendKeys(destination);
            subjectBoxElement.SendKeys(subject);
            bodyTextBoxElement.SendKeys(bodyText);
            if (attachment != "") {
                attachFileElement.SendKeys(Directory.GetCurrentDirectory() + "\\" + attachment);
            }
            sendButtonElement.Click();
        }
    }
}
