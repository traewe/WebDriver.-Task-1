using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PastebinTest
{
    public class PastebinPage
    {
        private IWebDriver driver;

        public PastebinPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            driver.Navigate().GoToUrl("https://pastebin.com");
        }

        public void CreateNewPaste(string code, string title)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("postform-text")));
            element.SendKeys(code);

            var expirationDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select2-postform-expiration-container")));
            expirationDropdown.Click();

            var option = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//li[text()='10 Minutes']")));
            option.Click();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('aria-activedescendant', 'select2-postform-expiration-result-fjlh-10M')", expirationDropdown);

            var titleInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("postform-name")));
            titleInput.SendKeys(title);

            var createButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.btn.-big[type='submit']")));
            createButton.Click();
        }


        public bool IsPasteCreatedSuccessfully()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var textarea = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("de1")));

            return textarea.Text == "Hello from WebDriver";
        }
    }
}
