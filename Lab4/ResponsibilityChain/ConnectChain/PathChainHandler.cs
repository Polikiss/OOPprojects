using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ConnectChain;

public class PathChainHandler : ArgumentChainBase
{
    public override ParseArgumentResult Handle(Request request, ConnectModel.Builder builder)
    {
        builder.WithPath(request.Arguments.Current);
        var mFlag = new ModeChainHandler();
        ParseArgumentResult result = new ParseArgumentResult.ParseArgumentSuccess();

        while (request.Arguments.MoveNext())
        {
            result = mFlag.Handle(request, builder);
            if (result is ParseArgumentResult.ParseArgumentFail flagFail)
            {
                return new ParseArgumentResult.ParseArgumentFail(flagFail.Message);
            }
        }

        return result;
    }
}