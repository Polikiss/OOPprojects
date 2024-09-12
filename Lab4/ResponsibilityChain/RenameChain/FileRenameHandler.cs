using System;
using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.RenameChain;

public class FileRenameHandler : ResponsibilityChainBase
{
    public override ParseResult Handle(Request request)
    {
        if (request.Arguments.Current.StartsWith("rename", StringComparison.Ordinal))
        {
            if (request.Arguments.MoveNext() is false)
                return new ParseResult.Fail("Missing Arguments");
            var builder = new FileRenameModel.Builder();
            var source = new RenamePathHandler();
            ParseArgumentResult result = source.Handle(request, builder);
            if (result is ParseArgumentResult.ParseArgumentFail sourceFail)
            {
                return new ParseResult.Fail(sourceFail.Message);
            }

            return new ParseResult.Success(new FileRenameCommand(builder.Build()));
        }

        return NextCommand is not null ? NextCommand.Handle(request) : new ParseResult.Fail("Unknown command");
    }
}