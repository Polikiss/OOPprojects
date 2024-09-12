using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CopyChain;

public abstract class CopyChainBase : ICopyArgumentsChain
{
    protected ICopyArgumentsChain? NextCommand { get; private set; }

    public void AddNext(ICopyArgumentsChain link)
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

    public abstract ParseArgumentResult Handle(Request request, FileCopyModel.Builder builder);
}