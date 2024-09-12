using System;
using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.DisconnectChain;

public class DisconnectHandler : ResponsibilityChainBase
{
    public override ParseResult Handle(Request request)
    {
        if (request.Arguments.Current.StartsWith("disconnect", StringComparison.Ordinal))
        {
            var result = new ParseResult.Success(new DisconnectCommand());
            return result;
        }
        else
        {
            return NextCommand is not null ? NextCommand.Handle(request) : new ParseResult.Fail("Unknown command");
        }
    }
}