using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.RenameChain;

public class RenamePathHandler : RenameChainBase
{
    public override ParseArgumentResult Handle(Request request, FileRenameModel.Builder builder)
    {
        builder.WithFilePath(request.Arguments.Current);
        if (request.Arguments.MoveNext() is false)
            return new ParseArgumentResult.ParseArgumentFail("Missing Arguments");
        var name = new RenameNameHandler();
        ParseArgumentResult result = name.Handle(request, builder);
        return result;
    }
}