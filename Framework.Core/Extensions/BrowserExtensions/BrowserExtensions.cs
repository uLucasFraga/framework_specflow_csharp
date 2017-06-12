using OpenQA.Selenium;

namespace Framework.Core.Extensions.BrowserExtensions
{
    public static class BrowserExtensions
    {
        public static object FindElements(this IWebDriver driver, string seletor1)
        {
            return driver.FindElements(By.Name(seletor1));
        }
    }
}
