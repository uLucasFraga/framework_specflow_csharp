using OpenQA.Selenium.Firefox;

namespace Framework.Core.Browsers
{
    public class FireFoxBrowser : BrowserBase
    {
       
        public override void Iniciar()
        {
            SetupDriver(new FirefoxDriver());
        }
    }
}
