using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class ConnectCommand : ICommand
{
    private readonly string _address;
    private readonly string _mode;
    public ConnectCommand(ConnectModel connectModel)
    {
        _address = connectModel.Path;
        _mode = connectModel.Mode;
    }

    public string Name => "connect";
    public void Execute(FileSystemContext context)
    {
        if (_mode == "local")
        {
            context.FileSystem = new LocalFileSystem(_address);
            context.CurrentPath = _address;
        }
    }
}