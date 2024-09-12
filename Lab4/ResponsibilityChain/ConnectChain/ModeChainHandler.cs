using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ConnectChain;

public class ModeChainHandler : ArgumentChainBase
{
    public override ParseArgumentResult Handle(Request request, ConnectModel.Builder builder)
    {
        if (request.Arguments.Current == "-m")
        {
            if (request.Arguments.MoveNext() is false)
                return new ParseArgumentResult.ParseArgumentFail("Missing flag");
            builder.WithMode(request.Arguments.Current);
            return new ParseArgumentResult.ParseArgumentSuccess();
        }

        return NextCommand?.Handle(request, builder) is not null ? NextCommand.Handle(request, builder) :
            new ParseArgumentResult.ParseArgumentFail("Unknown flag");
    }
}