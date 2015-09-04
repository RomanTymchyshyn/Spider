using System.Collections.Generic;

namespace Spider.Service
{
    public class ParsingResult
    {
        private List<string> _links;
        private bool _found;

        public ParsingResult(List<string> links, bool found)
        {
            _links = links;
            _found = found;
        }

        public List<string> Links
        {
            get { return _links; }
        }

        public bool Found
        {
            get { return _found; }
        }
    }
}
