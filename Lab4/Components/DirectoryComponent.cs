using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Components;

public class DirectoryComponent : IComponent
{
    private readonly string _name;
    private IList<IComponent> _components = new List<IComponent>();
    private string _output;

    public DirectoryComponent(string name)
    {
        _name = name;
        _output = string.Empty;
        Prefix = "---";
        Indent = "|   ";
    }

    public string Prefix { get; internal set; }
    public string Indent { get; internal set; }

    public void Add(IComponent component)
    {
        _components.Add(component);
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitDirectory(this);
        foreach (IComponent component in _components)
        {
            component.Accept(visitor);
        }
    }

    public string Print(int depth, string symbol = "")
    {
        if (depth <= 0)
            return string.Empty;

        _output += symbol + Prefix;
        symbol += Indent + symbol;
        _output += _name + '\n';
        foreach (IComponent tComponent in _components)
        {
            _output += tComponent.Print(depth - 1,  symbol);
        }

        return _output;
    }
}