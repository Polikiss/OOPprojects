using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Driver;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemResultType;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class FileShow : ICommand
{
    private readonly IWriter _writer;
    private readonly string _filepath;

    public FileShow(FileShowModel model)
    {
        _filepath = model.FilePath;
        _writer = model.Mode;
    }

    public FileShow(string filepath)
    {
        _filepath = filepath;
        _writer = new ConsoleWriter();
    }

    public string Name => "file show";
    public void Execute(FileSystemContext context)
    {
        if (context.FileSystem is null)
        {
            _writer.Print("No file System");
            return;
        }

        FileSystemResult result = context.FileSystem.Show(_filepath, context.CurrentPath, _writer);
        if (result is FileSystemResult.Fail fail)
        {
            _writer.Print(fail.Message);
        }
    }
}