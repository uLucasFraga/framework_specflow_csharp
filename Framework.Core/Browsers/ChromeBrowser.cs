using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Framework.Core.Browsers
{
    public class ChromeBrowser : BrowserBase
    {
      
        public override void Iniciar()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("password_manager_enabled", false);

            SetupDriver(new ChromeDriver(options));
        }
    }
}
