using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ConnectChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain;

public abstract class ArgumentChainBase : IConnectArgumentChain
{
    protected IConnectArgumentChain? NextCommand { get; private set; }

    public void AddNext(IConnectArgumentChain link)
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

    public abstract ParseArgumentResult Handle(Request request, ConnectModel.Builder builder);
}