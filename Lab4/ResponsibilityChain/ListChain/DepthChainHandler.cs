using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ListChain;

public class DepthChainHandler : ListArgumentChainBase
{
    public override ParseArgumentResult Handle(Request request, TreeListModel.Builder builder)
    {
        if (request.Arguments.Current.StartsWith("-d", StringComparison.Ordinal))
        {
            if (request.Arguments.MoveNext() is false)
                return new ParseArgumentResult.ParseArgumentFail("Missing flag");
            bool parse = int.TryParse(request.Arguments.Current, out int depth);
            if (parse is false)
            {
                return new ParseArgumentResult.ParseArgumentFail("Wrong flag");
            }

            builder.WithDepth(depth);
            return new ParseArgumentResult.ParseArgumentSuccess();
        }

        return NextCommand?.Handle(request, builder) is not null ? NextCommand.Handle(request, builder) :
            new ParseArgumentResult.ParseArgumentFail("Unknown flag");
    }
}