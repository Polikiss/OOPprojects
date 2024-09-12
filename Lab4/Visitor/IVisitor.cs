using Itmo.ObjectOrientedProgramming.Lab4.Components;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public interface IVisitor
{
    void VisitDirectory(DirectoryComponent component);
    void VisitFile(FileComponent component);
}