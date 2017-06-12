using System;
using System.Collections.Generic;
using Framework.Core.Interfaces;

namespace Framework.Core.Browsers
{
    public class BrowserFactory : Dictionary<string, Func<IBrowser>>,
     IBrowserFactory
    {
        public IBrowser Novo(string name) => this[name]();
    }
}
