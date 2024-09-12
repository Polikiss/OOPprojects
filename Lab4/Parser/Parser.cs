using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.ConnectChain;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.DisconnectChain;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.FileChain;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.TreeChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class Parser : IParser
{
    public ParseResult Pars(string input)
    {
        IList<string> arguments = input.Split(' ').ToList();
        IEnumerator<string> enumerator = arguments.GetEnumerator();
        var request = new Request(enumerator);
        if (request.Arguments.MoveNext() is false)
            return new ParseResult.Fail("MissingArguments");
        ICommandChain connect = new ConnectHandler();
        ICommandChain disconnect = new DisconnectHandler();
        ICommandChain tree = new TreeHandler();
        ICommandChain file = new FileHandler();
        connect.AddNext(disconnect);
        disconnect.AddNext(tree);
        tree.AddNext(file);

        ParseResult result = connect.Handle(request);

        return result;
    }
}