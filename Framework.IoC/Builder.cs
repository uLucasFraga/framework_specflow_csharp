using System;
using Framework.Core.Exceptions;
using Framework.Core.Interfaces;

namespace Framework.IoC
{
    public static class BrowserBuilder
    {
        public static IBrowser ObterBrowser(string navegador)
        {
            IoC.BeginLifeTimeScope();
            try
            {
                var browser = IoC.GetInstance<IBrowserFactory>().Novo(navegador);
                return browser;
            }
            catch (Exception)
            {
                throw new NavegadorNaoEncontradoException($"Houve um erro ao carregar o navegador: {navegador}.");
            }
           
        }
    }
}
