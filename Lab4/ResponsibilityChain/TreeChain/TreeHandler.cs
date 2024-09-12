using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.GotoChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.TreeChain;

public class TreeHandler : ResponsibilityChainBase
{
    public override ParseResult Handle(Request request)
    {
        if (request.Arguments.Current == "tree")
        {
            if (request.Arguments.MoveNext() is false)
                return new ParseResult.Fail("Missing arguments");

            ICommandChain treeGoto = new TreeGotoHandler();
            ICommandChain treeList = new TreeListHolder();
            treeGoto.AddNext(treeList);

            return treeGoto.Handle(request);
        }

        return NextCommand is not null ? NextCommand.Handle(request) : new ParseResult.Fail("Unknown command");
    }
}