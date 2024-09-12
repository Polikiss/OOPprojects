using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CopyChain;

public class DestinationPathChainHandler : CopyChainBase
{
    public override ParseArgumentResult Handle(Request request, FileCopyModel.Builder builder)
    {
        builder.WithFileDestinationPath(request.Arguments.Current);
        return new ParseArgumentResult.ParseArgumentSuccess();
    }
}