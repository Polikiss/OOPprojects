using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Components;

public interface IComponent
{
    public void Add(IComponent component);
    public void Accept(IVisitor visitor);
    public string Print(int depth, string symbol = "");
}