using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.MoveChain;

public interface IMoveArgumentChain
{
    public void AddNext(IMoveArgumentChain link);

    public ParseArgumentResult Handle(Request request, FileMoveModel.Builder builder);
}
