using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CopyChain;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.MoveChain;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.RenameChain;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ShowChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.FileChain;

public class FileHandler : ResponsibilityChainBase
{
    public override ParseResult Handle(Request request)
    {
        if (request.Arguments.Current == "file")
        {
            if (request.Arguments.MoveNext() is false)
                return new ParseResult.Fail("Missing arguments");

            ICommandChain copy = new FileCopyHandler();
            ICommandChain delete = new FileDeleteHandler();
            ICommandChain move = new FileMoveHandler();
            ICommandChain rename = new FileRenameHandler();
            ICommandChain show = new FileShowHandler();

            copy.AddNext(delete);
            delete.AddNext(move);
            move.AddNext(rename);
            rename.AddNext(show);

            return copy.Handle(request);
        }

        return NextCommand is not null ? NextCommand.Handle(request) : new ParseResult.Fail("Unknown command");
    }
}