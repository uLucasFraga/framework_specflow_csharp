using Framework.IoC;
using TechTalk.SpecFlow;
using Framework.Core.Interfaces;

using System.Linq;

namespace Tests.SGP.Hooks
{
    [Binding]
    public class FeatureHook
    {
        private static IBrowser Browser;

        [BeforeFeature]
        public static void Before()
        {
            Browser = BrowserBuilder.ObterBrowser(
                FeatureContext.Current.FeatureInfo.Tags.FirstOrDefault(f => f == "chrome" || f == "firefox" || f == "ie"));

            Browser.Iniciar();

            FeatureContext.Current.Add("browser", Browser);
        }

        [AfterFeature]
        public static void After()
        {
            Browser.Finalizar();
        }
    }
}
