using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Driver;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemResultType;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class FileCopyCommand : ICommand
{
    private string _fileSourcePath;
    private string _fileDestinationPath;
    private IWriter _writer = new ConsoleWriter();

    public FileCopyCommand(FileCopyModel model)
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

        FileSystemResult result = context.FileSystem.Copy(_fileSourcePath, context.CurrentPath, _fileDestinationPath);

        if (result is FileSystemResult.Fail fail)
        {
            _writer.Print(fail.Message);
        }
    }
}