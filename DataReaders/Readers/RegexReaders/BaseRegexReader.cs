using System.Text.RegularExpressions;

namespace DataReaders.Readers.RegexReaders;

public class BaseRegexReader
{
    private readonly Regex _regex;

    public BaseRegexReader(string regexPattern)
    {
        _regex = new Regex(regexPattern);
    }

    public Match GetMatch(string inputValue)
    {
        return _regex.Match(inputValue);
    }
}