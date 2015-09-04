using System.Collections.Generic;
using System.Text.RegularExpressions;
using Spider.Abstract;
using Spider.Service;

namespace Spider.Concrete
{
    public class RegExBasedHtmlParser: IParser
    {
        private const string _linkPattern = @"http(s)?://([\w-]+\.)+[\w-]+((/|\?)[]\w-./?%&=#,[@!$_~:-]*)?";

        public ParsingResult Parse(string html, string textToFind)
        {
            List<string> links = new List<string>();
            bool found = false;

            var regex = new Regex(_linkPattern);
            foreach (Match match in regex.Matches(html))
            {
                links.Add(match.Value);
            }

            regex = new Regex(Regex.Escape(textToFind));
            if (regex.IsMatch(html)) found = true;

            return new ParsingResult(links, found);
        }
    }
}
