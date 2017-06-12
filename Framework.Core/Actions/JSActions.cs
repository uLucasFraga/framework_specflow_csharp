using Framework.Core.Interfaces;
using OpenQA.Selenium;

namespace Framework.Core.Actions
{
    public static class JsActions
    {
        /// <summary>
        /// Executa o script fornecido na página atual.
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="script"></param>
        public static void ExecuteJs<T>(T browser, string script) where T : IBrowser
        {
            var js = (IJavaScriptExecutor)browser.ObterDriver();
            js.ExecuteScript(script);
        }
    }
}
