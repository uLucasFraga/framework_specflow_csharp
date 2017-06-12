using System;
using OpenQA.Selenium;


namespace Framework.Core.Interfaces
{
    public interface IBrowser : IDisposable
    {
        IWebDriver ObterDriver();
        string SwitchToGetText();
        string UrlAtual();
        void Iniciar();
        void Abrir(string url);
        void Fechar();
        void Finalizar();
        void RefreshPage();
        void BackPage();
        bool PageSource(string dados);
    }
}
