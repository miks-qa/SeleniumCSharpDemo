using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumCSharpDemo.Pages
{
    public class loginPage
    {
        private readonly IWebDriver driver;

        public loginPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        // Locators

        private readonly By usernameField = By.Id("user-name");
        private readonly By passwordField = By.Id("password");
        private readonly By loginButton = By.Id("login-button");
        private readonly By errorMessage = By.CssSelector("[data-test='error']");


        // Actions

        public void Open()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }


        public void EnterUsername(string username)
        {
            driver.FindElement(usernameField)
                  .SendKeys(username);
        }


        public void EnterPassword(string password)
        {
            driver.FindElement(passwordField)
                  .SendKeys(password);
        }


        public void ClickLogin()
        {
            driver.FindElement(loginButton)
                  .Click();
        }


        public string GetErrorMessage()
        {
            return driver.FindElement(errorMessage).Text;
        }


        // Combined action
        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();
        }
    }
}