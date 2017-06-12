using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace Framework.Core.Actions
{
    public static class MouseActions
    {
        public static void ClickMouseMoveToElementSML<T>(T browser, Element elemento) where T : IBrowser
        {
            elemento.IsClickable(browser);
            OpenQA.Selenium.Interactions.Actions actions = new OpenQA.Selenium.Interactions.Actions(browser.ObterDriver());
            actions.MoveToElement(browser.ObterDriver().FindElement(elemento.ObterBy())).Click().Build().Perform();
        }

        public static void MouseMoveToElementSML<T>(T browser, Element elemento) where T : IBrowser
        {
            elemento.IsClickable(browser);
            OpenQA.Selenium.Interactions.Actions actions = new OpenQA.Selenium.Interactions.Actions(browser.ObterDriver());
            actions.MoveToElement(browser.ObterDriver().FindElement(elemento.ObterBy())).Build().Perform();
        }

        public static void SelectCheckBoxATM<T>(T browser, Element elemento) where T : IBrowser
        {
            var checkStatus = browser.ObterDriver().FindElement(elemento.ObterBy()).Selected;

            if (checkStatus) return;
            
            elemento.ClicarEsperarElemento(browser);
        }

        public static void SelectElementATM<T>(T browser, Element elemento, string texto) where T : IBrowser
        {
            var selectElement = new SelectElement(BrowserHelpers.ObterIWebElement(browser, elemento));
            selectElement.SelectByText(texto);
        }

        public static void ClickATM<T>(T browser, Element elemento) where T : IBrowser
        {
            elemento.IsClickable(browser);
            browser.ObterDriver().FindElement(elemento.ObterBy()).Click();
        }
    }
}
