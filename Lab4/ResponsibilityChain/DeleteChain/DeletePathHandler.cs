using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.DeleteChain;

public class DeletePathHandler : DeleteChainBase
{
    public override ParseArgumentResult Handle(Request request, FileDeleteModel.Builder builder)
    {
        builder.WithFilePath(request.Arguments.Current);
        return new ParseArgumentResult.ParseArgumentSuccess();
    }
}