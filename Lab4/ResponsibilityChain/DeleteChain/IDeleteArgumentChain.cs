using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.DeleteChain;

public interface IDeleteArgumentChain
{
    public void AddNext(IDeleteArgumentChain link);

    public ParseArgumentResult Handle(Request request, FileDeleteModel.Builder builder);
}