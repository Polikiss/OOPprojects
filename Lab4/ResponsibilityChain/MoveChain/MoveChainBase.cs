using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.MoveChain;

public abstract class MoveChainBase : IMoveArgumentChain
{
    protected IMoveArgumentChain? NextCommand { get; private set; }

    public void AddNext(IMoveArgumentChain link)
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

    public abstract ParseArgumentResult Handle(Request request, FileMoveModel.Builder builder);
}