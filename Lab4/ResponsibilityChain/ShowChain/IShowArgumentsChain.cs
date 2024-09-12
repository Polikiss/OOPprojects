using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ShowChain;

public interface IShowArgumentsChain
{
    public void AddNext(IShowArgumentsChain link);

    public ParseArgumentResult Handle(Request request, FileShowModel.Builder builder);
}
