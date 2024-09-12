using System;
using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.MoveChain;

public class FileMoveHandler : ResponsibilityChainBase
{
    public override ParseResult Handle(Request request)
    {
        if (request.Arguments.Current.StartsWith("move", StringComparison.Ordinal))
        {
            if (request.Arguments.MoveNext() is false)
                return new ParseResult.Fail("Missing Arguments");
            var builder = new FileMoveModel.Builder();
            var source = new SourcePathChainHandler();
            ParseArgumentResult result = source.Handle(request, builder);
            if (result is ParseArgumentResult.ParseArgumentFail sourceFail)
            {
                return new ParseResult.Fail(sourceFail.Message);
            }

            return new ParseResult.Success(new FileMoveCommand(builder.Build()));
        }

        return NextCommand is not null ? NextCommand.Handle(request) : new ParseResult.Fail("Unknown command");
    }
}