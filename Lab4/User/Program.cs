using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Driver;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.ParseResults;
using Itmo.ObjectOrientedProgramming.Lab4.Reader;

namespace Itmo.ObjectOrientedProgramming.Lab4.User;

public static class Program
{
    public static void Main()
    {
        IFileSystem? fileSystem = null;
        var context = new FileSystemContext(fileSystem, string.Empty, "---", "|   ");
        var reader = new ConsoleReader();
        var parser = new Parser.Parser();
        var writer = new ConsoleWriter();
        while (true)
        {
            string? input = reader.Read();
            if (input is null) continue;
            ParseResult result = parser.Pars(input);
            if (result is ParseResult.Success success)
            {
               success.Command.Execute(context);
            }
            else if (result is ParseResult.Fail fail)
            {
                writer.Print(fail.FailReason);
            }
        }
    }
}