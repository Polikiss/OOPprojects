using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.MoveChain;

public class DestinationPathHandler : MoveChainBase
{
    public override ParseArgumentResult Handle(Request request, FileMoveModel.Builder builder)
    {
        builder.WithFileDestinationPath(request.Arguments.Current);
        return new ParseArgumentResult.ParseArgumentSuccess();
    }
}