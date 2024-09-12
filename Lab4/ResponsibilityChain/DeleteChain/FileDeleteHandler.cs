using System;
using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.DeleteChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain;

public class FileDeleteHandler : ResponsibilityChainBase
{
    public override ParseResult Handle(Request request)
    {
        if (request.Arguments.Current.StartsWith("delete", StringComparison.Ordinal))
        {
            if (request.Arguments.MoveNext() is false)
                return new ParseResult.Fail("Missing Arguments");
            var builder = new FileDeleteModel.Builder();
            var destination = new DeletePathHandler();
            ParseArgumentResult result = destination.Handle(request, builder);

            if (result is ParseArgumentResult.ParseArgumentFail destinationFail)
            {
                return new ParseResult.Fail(destinationFail.Message);
            }

            return new ParseResult.Success(new FileDeleteCommand(builder.Build()));
        }

        return NextCommand is not null ? NextCommand.Handle(request) : new ParseResult.Fail("Unknown command");
    }
}