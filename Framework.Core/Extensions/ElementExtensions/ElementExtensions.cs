using System;
using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Framework.Core.Actions;
using Framework.Core.Exceptions;

namespace Framework.Core.Extensions.ElementExtensions
{
    public static class ElementExtensions
    {
        private static int SEGUNDOS_TIMEOUT_ELEMENTO = 80;

        public static bool IsClickable(this Element elemento, IBrowser browser)
        {
            var iWebElement = BrowserHelpers.ObterIWebElement(browser, elemento);
            var wait = new WebDriverWait(browser.ObterDriver(), TimeSpan.FromSeconds(SEGUNDOS_TIMEOUT_ELEMENTO));
            wait.Until(ExpectedConditions.ElementToBeClickable(elemento.ObterBy()));

            return iWebElement.Displayed;
        }

        public static void ClickIFrame(this Element iFrame, Element elemento, IBrowser browser)
        {
            var wait = new WebDriverWait(browser.ObterDriver(), TimeSpan.FromSeconds(SEGUNDOS_TIMEOUT_ELEMENTO));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(iFrame.ObterBy()));

            elemento.ClicarEsperarElemento(browser);
        }

        public static void ApagarEditarDados(this Element elemento, string dados, IBrowser browser)
        {
            if (elemento.IsClickable(browser))
                MouseActions.ClickATM(browser, elemento);

            AutomatedActions.SendDataATM(browser, elemento, Keys.Backspace);
            elemento.Esperar(browser, 10);
            AutomatedActions.SendDataATM(browser, elemento, Keys.Backspace);
            AutomatedActions.SendDataATM(browser, elemento, dados);
            AutomatedActions.SendDataATM(browser, elemento, Keys.Enter);
        }

        public static void ClicarEsperarElemento(this Element elemento, IBrowser browser)
        {
            if (elemento.IsClickable(browser))
                MouseActions.ClickATM(browser, elemento);

            else
                throw new ElementoNaoEncontrado("Elemento não foi encontrado ou não está clicável.");
        }

        public static void ClicarInteligente(this Element elemento, IBrowser browser)
        {
            var sucesso = false;
            var execucoes = 3;

            while (!sucesso && execucoes > 0)
            {
                try
                {
                    execucoes--;
                    BrowserHelpers.ObterIWebElement(browser, elemento).Click();
                    sucesso = true;
                }
                catch (Exception)
                {
                    Thread.Sleep(SEGUNDOS_TIMEOUT_ELEMENTO);

                    if (execucoes == 0)
                        throw new ElementoNaoEncontrado($"O elemento {elemento} não foi encontrado.");
                }
            }
        }

        public static void Esperar(this Element elemento, IBrowser browser, int tempo)
        {
            WaitForAjax(browser.ObterDriver(), 40, false);
            Thread.Sleep(tempo);
        }

        /// <summary>
        /// Espera o elemento aparecer na pagina
        /// </summary>
        /// <param name="elemento">Elemento esperado</param>
        /// <param name="browser">objeto do navegador</param>
        public static void EsperarElemento(this Element elemento, IBrowser browser)
        {
            WaitForAjax(browser.ObterDriver(), 40, false);
            var wait = new WebDriverWait(browser.ObterDriver(), TimeSpan.FromSeconds(SEGUNDOS_TIMEOUT_ELEMENTO));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(elemento.ObterBy()));
        }

        private static void WaitForAjax(this IWebDriver driver, int timeoutSecs = 40, bool throwException = false)
        {
            for (var i = 0; i < timeoutSecs; i++)
            {
                var javaScriptExecutor = driver as IJavaScriptExecutor;
                var ajaxIsComplete = javaScriptExecutor != null && (bool)javaScriptExecutor.ExecuteScript("return jQuery.active == 0");
                if (ajaxIsComplete) return;
                Thread.Sleep(1000);
            }

            if (throwException)
                throw new TempoExpiradoException("O tempo limite da espera do AJAX foi completa");
        }

        public static string GetTexto(this Element elemento, IBrowser browser)
        {
            return browser.ObterDriver().FindElement(elemento.ObterBy()).Text;
        }

        public static bool IsElementVisible(this Element elemento, IBrowser browser)
        {
            var iWebElement = BrowserHelpers.ObterIWebElement(browser, elemento);
            return iWebElement.Displayed && iWebElement.Enabled;
        }
    }
}