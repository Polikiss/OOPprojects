using Itmo.ObjectOrientedProgramming.Lab4.Components;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public class Visitor : IVisitor
{
    private string _prefix;
    private string _indent;

    public Visitor(string prefix, string indent)
    {
        _prefix = prefix;
        _indent = indent;
    }

    public void VisitDirectory(DirectoryComponent component)
    {
        component.Prefix = _prefix;
        component.Indent = _indent;
    }

    public void VisitFile(FileComponent component)
    {
        component.Prefix = _prefix;
    }
}