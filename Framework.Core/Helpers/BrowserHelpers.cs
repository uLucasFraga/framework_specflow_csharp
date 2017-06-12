using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using OpenQA.Selenium;
using System.Threading;

namespace Framework.Core.Helpers
{
    public static class BrowserHelpers
    {
        public static IWebElement ObterIWebElement(IBrowser browser, Element element)
        {
            return browser.ObterDriver().FindElement(element.ObterBy());
        }

       public static IJavaScriptExecutor Scripts(this IBrowser browser)
        {
            return browser as IJavaScriptExecutor;
        }

        public static void EsperarJQueryAjax(IBrowser browser)
        {
            var jQueryStatus = (bool)(browser.Scripts().ExecuteScript("return (typeof(jQuery) != 'undefined')"));
            if (!jQueryStatus) return;

            while (true)
            {
                var ajaxCompleto = (bool)(browser.Scripts().ExecuteScript("return jQuery.active ==0"));
                if (ajaxCompleto) break;
                Thread.Sleep(100);
            }
        }
    }
}