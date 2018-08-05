using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

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

        [FindsBy(How = How.XPath, Using = "//*[@id=':a5']")]
        private IWebElement bodyTextBoxElement;

        public void SendMail(string destination)
        {
            //Needs improvement because of user locale while running the webdriver
            //Needs more implementation since the scope of testing isn't complete
            composeElement.Click();
            destinationInput.Clear();
            destinationInput.SendKeys(destination);
            bodyTextBoxElement.SendKeys(destination);
            sendButtonElement.Click();
        }
    }
}
