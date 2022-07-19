using NUnit.Framework;
using OpenQA.Selenium;
using System.Drawing;
using System.Threading;

namespace YandexTests
{
    public class Tests
    {
        private readonly By searchFieldBy = By.XPath("//input[@id='text']");
        private readonly By searchButtonBy = By.XPath("//button[@type='submit']");
        private readonly By testUrl = By.XPath("//a[@href='https://rowi.com/']");

        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://yandex.ru/");
            driver.Manage().Window.Size = new Size(1280, 1024);
        }

        [Test]
        public void TestSearchCompanySite()
        {
            var searchField = driver.FindElement(searchFieldBy);
            searchField.SendKeys("Rowi");

            var searchButton = driver.FindElement(searchButtonBy);
            searchButton.Click();
            Thread.Sleep(1000);

            var testUrls = driver.FindElements(testUrl);
            if (testUrls.Count == 0)
            {
                Assert.Fail("Тестовая ссылка не найдена");
            }
           
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}