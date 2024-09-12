using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.GotoChain;

public interface IGotoArgumentChain
{
    public void AddNext(IGotoArgumentChain link);

    public ParseArgumentResult Handle(Request request, TreeGotoModel.Builder builder);
}