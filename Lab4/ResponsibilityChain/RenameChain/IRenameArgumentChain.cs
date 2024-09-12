using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.RenameChain;

public interface IRenameArgumentChain
{
    public void AddNext(IRenameArgumentChain link);

    public ParseArgumentResult Handle(Request request, FileRenameModel.Builder builder);
}