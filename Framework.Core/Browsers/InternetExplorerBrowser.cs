using OpenQA.Selenium.IE;

namespace Framework.Core.Browsers
{
    public class InternetExplorerBrowser : BrowserBase
    {
        public override void Iniciar()
        {
            SetupDriver(new InternetExplorerDriver(new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true
            }));
        }
    }
}
