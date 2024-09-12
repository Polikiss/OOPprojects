using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.GotoChain;

public abstract class GotoChainBase : IGotoArgumentChain
{
    protected IGotoArgumentChain? NextCommand { get; private set; }

    public void AddNext(IGotoArgumentChain link)
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

    public abstract ParseArgumentResult Handle(Request request, TreeGotoModel.Builder builder);
}