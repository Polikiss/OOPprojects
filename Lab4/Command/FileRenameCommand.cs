using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Driver;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemResultType;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class FileRenameCommand : ICommand
{
    private readonly string _filePath;
    private readonly string _name;
    private readonly IWriter _writer = new ConsoleWriter();

    public FileRenameCommand(FileRenameModel model)
    {
        _filePath = model.FilePath;
        _name = model.Name;
    }

    public string Name => "file rename";
    public void Execute(FileSystemContext context)
    {
        if (context.FileSystem is null)
        {
            _writer.Print("No file System");
            return;
        }

        FileSystemResult result = context.FileSystem.Rename(_filePath, _name, context.CurrentPath);

        if (result is FileSystemResult.Fail fail)
        {
            _writer.Print(fail.Message);
        }
    }
}