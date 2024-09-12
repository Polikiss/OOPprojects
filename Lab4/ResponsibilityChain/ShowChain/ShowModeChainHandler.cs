using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.Driver;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ShowChain;

public class ShowModeChainHandler : ShowArgumentsChainBase
{
    public override ParseArgumentResult Handle(Request request,  FileShowModel.Builder builder)
    {
        if (request.Arguments.Current == "-m")
        {
            if (request.Arguments.MoveNext() is false)
                return new ParseArgumentResult.ParseArgumentFail("Missing flag");

            if (request.Arguments.Current == "console")
            {
                builder.WithMode(new ConsoleWriter());
                return new ParseArgumentResult.ParseArgumentSuccess();
            }

            return new ParseArgumentResult.ParseArgumentFail("Unknown flag");
        }

        return NextCommand?.Handle(request, builder) is not null ? NextCommand.Handle(request, builder) :
            new ParseArgumentResult.ParseArgumentFail("Unknown flag");
    }
}