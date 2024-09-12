using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ListChain;

public abstract class ListArgumentChainBase : IListArgumentChain
{
    protected IListArgumentChain? NextCommand { get; private set; }

    public void AddNext(IListArgumentChain link)
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

    public abstract ParseArgumentResult Handle(Request request, TreeListModel.Builder builder);
}