using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CrossMail.Tests
{
    public class GMailLoginPage
    {
        private IWebDriver driver;
        public GMailLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "identifierId")]
        private IWebElement userInput;

        [FindsBy(How = How.Id, Using = "identifierNext")]
        private IWebElement userInputNextButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='password']//input")]
        private IWebElement passInput;

        [FindsBy(How = How.Id, Using = "passwordNext")]
        private IWebElement passInputNextButton;

        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://mail.google.com/");
        }

        public GMailInboxPage Login(string user, string password)
        {
            userInput.SendKeys(user);
            userInputNextButton.Click();
            
            passInput.SendKeys(password);
            passInputNextButton.Click();

            return new GMailInboxPage(driver);
        }
    }
}
