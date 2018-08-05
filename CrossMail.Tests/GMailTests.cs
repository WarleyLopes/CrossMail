using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace CrossMail.Tests
{
    public class GMailTests: IDisposable
    {
        IWebDriver _browserDriver;
        IConfiguration _config;
        public GMailTests()
        {
            _browserDriver = new ChromeDriver("./");
            _browserDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
        }

        public void Dispose()
        {
            _browserDriver.Quit();
        }

        [Fact]
        public void Should_Send_Email()
        {
            GMailLoginPage gMailLoginPage = new GMailLoginPage(_browserDriver);

            gMailLoginPage.goToPage();

            GMailInboxPage gMailInboxPage = gMailLoginPage.Login(_config["username"], _config["password"]);

            gMailInboxPage.SendMail($"{_config["username"]}@gmail.com");

            //Needs improvement because of user locale while running the webdriver (compose button, 'to' field changes)
            //Needs more implementation since the scope of testing isn't complete
        }
    }
}
