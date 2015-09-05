namespace Spider.Parsers
{
    public interface IParser
    {
        ParsingResult Parse(string content, string textToFind);
    }
}
