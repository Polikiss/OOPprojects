using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.RenameChain;

public abstract class RenameChainBase
{
    protected IRenameArgumentChain? NextCommand { get; private set; }

    public void AddNext(IRenameArgumentChain link)
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

    public abstract ParseArgumentResult Handle(Request request, FileRenameModel.Builder builder);
}