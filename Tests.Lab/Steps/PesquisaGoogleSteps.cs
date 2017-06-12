using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class PesquisaGoogleSteps
    {
        public PesquisaGooglePage TelaPesquisaGoogle { get; private set; }

        public PesquisaGoogleSteps()
        {
            var browser = FeatureContext.Current["browser"];
            TelaPesquisaGoogle = new PesquisaGooglePage((IBrowser)browser,
                    ConfigurationManager.AppSettings["GooglePesquisaURL"],
                    ConfigurationManager.AppSettings["GitHubURL"]);
        }

        [Given(@"que eu esteja no site do Google")]
        public void DadoQueEuEstejaNoSiteDoGoogle()
        {
            TelaPesquisaGoogle.Navegar();
        }

        [When(@"realizar uma pesquisa")]
        public void QuandoRealizarUmaPesquisa()
        {
            TelaPesquisaGoogle.Pesquisar("github");
        }

        [Then(@"vejo mensagem com sucesso")]
        public void EntaoVejoMensagemComSucesso()
        {
            TelaPesquisaGoogle.VerificarPesquisa();
        }
    }
}
