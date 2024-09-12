using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain;

public interface ICommandChain
{
    public void AddNext(ICommandChain link);

    public ParseResult Handle(Request request);
}