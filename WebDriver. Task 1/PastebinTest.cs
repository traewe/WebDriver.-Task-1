using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PastebinTest
{
    [TestFixture]
    public class PastebinTest
    {
        private IWebDriver driver;
        private PastebinPage pastebinPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            pastebinPage = new PastebinPage(driver);
        }

        [Test]
        public void CreateNewPaste()
        {
            pastebinPage.Open();

            pastebinPage.CreateNewPaste("Hello from WebDriver", "helloweb");

            Assert.That(pastebinPage.IsPasteCreatedSuccessfully(), Is.EqualTo(true));
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
