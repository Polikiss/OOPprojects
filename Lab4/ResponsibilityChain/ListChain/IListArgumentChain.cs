using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ListChain;

public interface IListArgumentChain
{
    public void AddNext(IListArgumentChain link);

    public ParseArgumentResult Handle(Request request, TreeListModel.Builder builder);
}