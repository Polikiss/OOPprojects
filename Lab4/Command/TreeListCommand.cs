using Itmo.ObjectOrientedProgramming.Lab4.CommandModel;
using Itmo.ObjectOrientedProgramming.Lab4.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Driver;
using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class TreeListCommand : ICommand
{
    private readonly int _depth;
    private readonly IWriter _writer;

    public TreeListCommand(TreeListModel model, IWriter writer)
    {
        _depth = model.Depth;
        _writer = writer;
    }

    public TreeListCommand(TreeListModel model)
    {
        _depth = model.Depth;
        _writer = new ConsoleWriter();
    }

    public string Name => "tree list";
    public void Execute(FileSystemContext context)
    {
        if (context.FileSystem is null)
        {
            _writer.Print("No file System");
            return;
        }

        IComponent fileSystemTree = context.FileSystem.CreateComponent(context.CurrentPath, _depth);
        IVisitor visitor = new Visitor.Visitor(context.Prefix, context.Indent);
        fileSystemTree.Accept(visitor);
        string tree = fileSystemTree.Print(_depth);
        _writer.Print(tree);
    }
}