using System;
using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ConnectChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ShowChain;

public class FileShowHandler : ResponsibilityChainBase
{
    public override ParseResult Handle(Request request)
    {
        if (request.Arguments.Current.StartsWith("show", StringComparison.Ordinal))
        {
            var builder = new FileShowModel.Builder();
            var path = new ShowPathChainHandler();
            ParseArgumentResult result = path.Handle(request, builder);
            if (result is ParseArgumentResult.ParseArgumentFail fail)
            {
                return new ParseResult.Fail(fail.Message);
            }

            FileShowModel command = builder.Build();
            return new ParseResult.Success(new FileShow(command));
        }

        return NextCommand is not null ? NextCommand.Handle(request) : new ParseResult.Fail("Unknown command");
    }
}