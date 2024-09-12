using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CopyChain;

public class SourcePathChainHandler : CopyChainBase
{
    public override ParseArgumentResult Handle(Request request, FileCopyModel.Builder builder)
    {
        builder.WithFileSourcePath(request.Arguments.Current);
        if (request.Arguments.MoveNext() is false)
            return new ParseArgumentResult.ParseArgumentFail("Missing Arguments");
        var destination = new DestinationPathChainHandler();
        ParseArgumentResult result = destination.Handle(request, builder);
        return result;
    }
}