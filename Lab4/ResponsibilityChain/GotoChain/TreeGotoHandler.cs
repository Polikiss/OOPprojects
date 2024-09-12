using System;
using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.GotoChain;

public class TreeGotoHandler : ResponsibilityChainBase
{
    public override ParseResult Handle(Request request)
    {
        if (request.Arguments.Current.StartsWith("goto", StringComparison.Ordinal))
        {
            if (request.Arguments.MoveNext() is false)
                return new ParseResult.Fail("Missing Arguments");
            var builder = new TreeGotoModel.Builder();
            var destination = new GotoPathHandler();
            ParseArgumentResult result = destination.Handle(request, builder);

            if (result is ParseArgumentResult.ParseArgumentFail destinationFail)
            {
                return new ParseResult.Fail(destinationFail.Message);
            }

            return new ParseResult.Success(new TreeGotoCommand(builder.Build()));
        }

        return NextCommand is not null ? NextCommand.Handle(request) : new ParseResult.Fail("Unknown command");
    }
}