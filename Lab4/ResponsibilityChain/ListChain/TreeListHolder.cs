using System;
using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ListChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain;

public class TreeListHolder : ResponsibilityChainBase
{
    public override ParseResult Handle(Request request)
    {
        if (request.Arguments.Current.StartsWith("list", StringComparison.Ordinal))
        {
            var builder = new TreeListModel.Builder();
            while (request.Arguments.MoveNext())
            {
                var mFlag = new DepthChainHandler();
                ParseArgumentResult result = mFlag.Handle(request, builder);
                if (result is ParseArgumentResult.ParseArgumentFail flagFail)
                {
                    return new ParseResult.Fail(flagFail.Message);
                }
            }

            TreeListModel command = builder.Build();
            return new ParseResult.Success(new TreeListCommand(command));
        }

        return NextCommand is not null ? NextCommand.Handle(request) : new ParseResult.Fail("Unknown command");
    }
}