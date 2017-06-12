using Framework.Core.Interfaces;

namespace Framework.Core.PageObjects
{
    public abstract class PageBase : IPage
    {
        protected IBrowser Browser { get; }

        protected PageBase(IBrowser browser)
        {
            Browser = browser;
        }

        public abstract void Navegar();

        public void Finalizar()
        {
            Browser.Finalizar();
        }
    }
}
