using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace BehaviorAgency.Host.Core
{
    public class HtmlAgilityPackHandler
    {
        private HtmlDocument _document;

        public HtmlAgilityPackHandler(string htmlFilePath) {
            _document = new HtmlDocument();
            _document.Load(htmlFilePath);
        }

        public List<string> Scripts
        {
            get
            {
                return ResolveElements("//script");
            }
        }

        public List<string> Styles
        {
            get
            {
                return ResolveElements("//style");
            }
        }

        public List<string> Links
        {
            get
            {
                return ResolveElements("//link");
            }
        }

        private List<string> ResolveElements(string XPath)
        {
            var elements = new List<string>();
            var nodes = _document.DocumentNode.SelectNodes(XPath);           
            if (nodes != null && nodes.Count > 0)
                elements = nodes.Select(n => n.OuterHtml).ToList();
            return elements;
        }

        
    }
}
