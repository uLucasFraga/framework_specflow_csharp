using System;
using Framework.Core.Exceptions;
using OpenQA.Selenium;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;

namespace Framework.Core.Browsers
{
    public abstract class BrowserBase : IBrowser
    {
        #region Fields and Constructor
        private IWebDriver Driver;
        #endregion

        #region Methods
        private void Dispose(bool disposing)
        {
            if (!disposing) return;

            Driver?.Dispose();
        }

        protected void SetupDriver<T>(T driver) where T : IWebDriver
        {
            Driver = driver;
        }

        /// <summary>
        /// Abre o navegador
        /// </summary>
        public abstract void Iniciar();

        /// <summary>
        /// Retorna a url da página atual
        /// </summary>
        /// <returns></returns>
        public string UrlAtual()
        {
            return Driver.Url;
        }

        /// <summary>
        /// Direciona para um url
        /// </summary>
        /// <param name="url"></param>
        public void Abrir(string url)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Fecha o navegador 
        /// </summary>
        public void Fechar()
        {
            Driver.Close();
        }

        /// <summary>
        /// Finaliza o driver do navegador
        /// </summary>
        public void Finalizar()
        {
            Driver.Quit();
        }

        /// <summary>
        /// Preenche um elemento do tipo input[type="text"]
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="dados"></param>
        public void InformarDados(Element elemento, string dados)
        {
            Driver.FindElement(elemento.ObterBy()).SendKeys(dados);
        }

        /// <summary>
        /// Recarrega a página
        /// </summary>
        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        /// <summary>
        /// Executa um history.back
        /// </summary>
        public void BackPage()
        {
            Driver.Navigate().Back();
        }

        public IWebDriver ObterDriver()
        {
            return Driver;
        }

        public bool PageSource(string dados)
        {
           return Driver.PageSource.Contains(dados);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string SwitchToGetText()
        {
            return Driver.SwitchTo().Alert().Text;
        }
        #endregion
    }
}
