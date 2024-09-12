using Itmo.ObjectOrientedProgramming.Lab4.Context;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class DisconnectCommand : ICommand
{
    public string Name => "disconnect";
    public void Execute(FileSystemContext context)
    {
        context.FileSystem = null;
    }
}