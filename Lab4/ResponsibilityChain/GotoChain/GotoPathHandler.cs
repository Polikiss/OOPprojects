using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.GotoChain;

public class GotoPathHandler : GotoChainBase
{
    public override ParseArgumentResult Handle(Request request, TreeGotoModel.Builder builder)
    {
        builder.WithFilePath(request.Arguments.Current);
        return new ParseArgumentResult.ParseArgumentSuccess();
    }
}