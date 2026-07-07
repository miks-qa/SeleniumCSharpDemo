using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCSharpDemo.Pages;

namespace SeleniumCSharpDemo
{
    [TestFixture]
    public class loginTests
    {
        private IWebDriver driver;
        private loginPage loginPageObject;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            driver.Manage()
                  .Window
                  .Maximize();

            loginPageObject = new loginPage(driver);
        }


        [Test]
        public void Scenario1_ValidLogin()
        {
            // Scenario 1 - Login with valid credentials

            loginPageObject.Open();
            loginPageObject.Login("standard_user", "secret_sauce");

            Assert.That(
                driver.Url,
                Does.Contain("inventory")
            );
        }


        [Test]
        public void Scenario2_InvalidLogin()
        {
            // Scenario 2 - Login with invalid credentials

            loginPageObject.Open();
            loginPageObject.Login("standard_user","wrong_password");

            Assert.That(
                loginPageObject.GetErrorMessage(),
                Does.Contain("Username and password do not match")
            );
        }


        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}