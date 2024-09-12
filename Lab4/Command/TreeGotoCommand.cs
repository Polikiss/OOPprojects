using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Driver;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class TreeGotoCommand : ICommand
{
    private readonly IWriter _writer = new ConsoleWriter();
    private string _filePath;

    public TreeGotoCommand(TreeGotoModel model)
    {
        _filePath = model.FilePath;
    }

    public string Name => "tree goto";

    public void Execute(FileSystemContext context)
    {
        if (context.FileSystem is null)
        {
            _writer.Print("File system is not exist");
            return;
        }

        if (context.FileSystem.IsPathRooted(_filePath) is false)
        {
            _filePath = context.CurrentPath + _filePath;
        }

        if (context.FileSystem.IsDirectoryExists(_filePath) is false)
        {
            _writer.Print("Directory is not exist");
            return;
        }

        context.CurrentPath = _filePath;
    }
}