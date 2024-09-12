using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.MoveChain;

public class SourcePathChainHandler : MoveChainBase
{
    public override ParseArgumentResult Handle(Request request, FileMoveModel.Builder builder)
    {
        builder.WithFileSourcePath(request.Arguments.Current);
        if (request.Arguments.MoveNext() is false)
            return new ParseArgumentResult.ParseArgumentFail("Missing Arguments");
        var destination = new DestinationPathHandler();
        ParseArgumentResult result = destination.Handle(request, builder);

        return result;
    }
}