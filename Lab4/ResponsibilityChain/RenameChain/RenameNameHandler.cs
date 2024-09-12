using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.RenameChain;

public class RenameNameHandler : RenameChainBase
{
    public override ParseArgumentResult Handle(Request request, FileRenameModel.Builder builder)
    {
        builder.WithName(request.Arguments.Current);
        return new ParseArgumentResult.ParseArgumentSuccess();
    }
}