using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Driver;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemResultType;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class FileDeleteCommand : ICommand
{
    private readonly string _filePath;
    private readonly IWriter _writer = new ConsoleWriter();

    public FileDeleteCommand(FileDeleteModel model)
    {
        _filePath = model.FilePath;
    }

    public string Name => "delete";
    public void Execute(FileSystemContext context)
    {
        if (context.FileSystem is null)
        {
            _writer.Print("No file System");
            return;
        }

        FileSystemResult result = context.FileSystem.Delete(_filePath, context.CurrentPath);

        if (result is FileSystemResult.Fail fail)
        {
            _writer.Print(fail.Message);
        }
    }
}