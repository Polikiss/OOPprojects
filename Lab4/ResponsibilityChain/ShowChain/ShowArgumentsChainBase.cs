using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ShowChain;

public abstract class ShowArgumentsChainBase : IShowArgumentsChain
{
    protected IShowArgumentsChain? NextCommand { get; private set; }

    public void AddNext(IShowArgumentsChain link)
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

    public abstract ParseArgumentResult Handle(Request request, FileShowModel.Builder builder);
}