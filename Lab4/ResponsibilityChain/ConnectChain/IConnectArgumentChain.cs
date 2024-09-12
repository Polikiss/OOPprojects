using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ConnectChain;

public interface IConnectArgumentChain
{
    public void AddNext(IConnectArgumentChain link);

    public ParseArgumentResult Handle(Request request, ConnectModel.Builder builder);
}