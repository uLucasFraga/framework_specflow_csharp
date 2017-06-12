
using System;
using Framework.Core.Interfaces;
using OpenQA.Selenium;

namespace Framework.Core.PageObjects
{
    public class Element
    {
        private readonly By _by;

        private Element(By by)
        {
            _by = by;
        }

        public static Element Id(string id)
        {
            return new Element(By.Id(id));
        }

        public static Element Xpath(string xpath)
        {
            return new Element(By.XPath(xpath));
        }

        public static Element TagName(string tagName)
        {
            return new Element(By.TagName(tagName));
        }

        public static Element Css(string css)
        {
            return new Element(By.CssSelector(css));
        }

        public static Element Nome(string nome)
        {
            return new Element(By.Name(nome));
        }

        public static Element Link(string link)
        {
            return new Element(By.LinkText(link));
        }

        public static Element Class(string classe)
        {
            return new Element(By.ClassName(classe));
        }
        
        protected internal By ObterBy()
        {
            return _by;
        }
    }
}
