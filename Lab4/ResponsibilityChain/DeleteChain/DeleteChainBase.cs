using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.DeleteChain;

public abstract class DeleteChainBase : IDeleteArgumentChain
{
    protected IDeleteArgumentChain? NextCommand { get; private set; }

    public void AddNext(IDeleteArgumentChain link)
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

    public abstract ParseArgumentResult Handle(Request request, FileDeleteModel.Builder builder);
}