using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Components;

public class FileComponent : IComponent
{
    private readonly string _name;
    private readonly IList<IComponent> _components = new List<IComponent>();
    private string _output;

    public FileComponent(string name)
    {
        _name = name;
        _output = string.Empty;
        Prefix = "---";
    }

    public string Prefix { get; internal set; }

    public void Add(IComponent component)
    {
        _components.Add(component);
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitFile(this);
    }

    public string Print(int depth, string symbol = "")
    {
        _output += symbol + Prefix + _name + '\n';
        return _output;
    }
}