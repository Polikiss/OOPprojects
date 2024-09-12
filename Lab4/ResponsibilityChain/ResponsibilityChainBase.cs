using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain;

public abstract class ResponsibilityChainBase : ICommandChain
{
    protected ICommandChain? NextCommand { get; private set; }
    public void AddNext(ICommandChain link)
    {
        if (NextCommand is null)
        {
            NextCommand = link;
        }
        else
        {
            NextCommand.AddNext(link);
        }
    }

    public abstract ParseResult Handle(Request request);
}