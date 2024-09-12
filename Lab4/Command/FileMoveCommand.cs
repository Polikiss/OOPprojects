using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Driver;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemResultType;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class FileMoveCommand : ICommand
{
    private readonly string _fileSourcePath;
    private readonly string _fileDestinationPath;
    private readonly IWriter _writer = new ConsoleWriter();

    public FileMoveCommand(FileMoveModel model)
    {
        _fileSourcePath = model.FileSourcePath;
        _fileDestinationPath = model.FileDestinationPath;
    }

    public string Name => "file move";

    public void Execute(FileSystemContext context)
    {
        if (context.FileSystem is null)
        {
            _writer.Print("No file System");
            return;
        }

        FileSystemResult result = context.FileSystem.MoveTo(_fileSourcePath, _fileDestinationPath, context.CurrentPath);
        if (result is FileSystemResult.Fail fail)
        {
            _writer.Print(fail.Message);
        }
    }
}