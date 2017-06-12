using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using System;

namespace Project.SGP.Pages
{
    public class PesquisaGooglePage : PageBase
    {
        private string textoPagina = "The world's leading software development platform · GitHub";

        private string GooglePesquisaUrl { get; }
        private string GitHubUrl { get; }


        //Google Pesquisa
        private Element InputPesquisar { get; }
        private Element LinkPesquisa { get; }


        public PesquisaGooglePage(IBrowser browser,
            string googlePesquisaUrl,
            string githubUrl) : base(browser)
        {
            GooglePesquisaUrl = googlePesquisaUrl;
            GitHubUrl = githubUrl;

            //Google Pesquisa
            InputPesquisar = Element.Id("lst-ib");
            LinkPesquisa = Element.Link(textoPagina);


        }

        //-------------------METODOS-------------------\\
        public override void Navegar()
        {
            Browser.Abrir(GooglePesquisaUrl);
        }

        public void Pesquisar(string pesquisar)
        {
            AutomatedActions.SendDataATM(Browser, InputPesquisar, pesquisar);
            KeyboardActions.Enter(Browser, InputPesquisar);

            SelecionarPesquisa();
        }

        public bool VerificarPesquisa()
        {
            return Browser.UrlAtual() == GitHubUrl;
        }

        private void SelecionarPesquisa()
        {
            if (LinkPesquisa.IsClickable(Browser))
            {
                MouseActions.ClickATM(Browser, LinkPesquisa);
            }
            else
            {
                throw new TimeoutException("Texto não está disponível.");
            }
        }
    }
}