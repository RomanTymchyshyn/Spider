using System.Collections.Generic;
using Spider.Service;

namespace Spider.Abstract
{
    public interface IParser
    {
        ParsingResult Parse(string content, string textToFind);
    }
}
