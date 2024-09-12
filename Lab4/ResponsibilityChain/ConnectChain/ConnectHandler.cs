using System;
using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;
using Itmo.ObjectOrientedProgramming.Lab4.ParsResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ConnectChain;

public class ConnectHandler : ResponsibilityChainBase
{
    private readonly IConnectArgumentChain _connectPathChain = new PathChainHandler();

    public override ParseResult Handle(Request request)
    {
        if (request.Arguments.Current.StartsWith("connect", StringComparison.Ordinal))
        {
            if (request.Arguments.MoveNext() is false)
                return new ParseResult.Fail("Missing arguments");
            var builder = new ConnectModel.Builder();
            ParseArgumentResult result = _connectPathChain.Handle(request, builder);
            if (result is ParseArgumentResult.ParseArgumentFail fail)
            {
                return new ParseResult.Fail(fail.Message);
            }

            ConnectModel command = builder.Build();
            return new ParseResult.Success(new ConnectCommand(command));
        }

        return NextCommand is not null ? NextCommand.Handle(request) : new ParseResult.Fail("Unknown command");
    }
}