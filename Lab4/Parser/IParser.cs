using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public interface IParser
{
    public ParseResult Pars(string input);
}