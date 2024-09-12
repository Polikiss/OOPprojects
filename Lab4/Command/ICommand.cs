using Itmo.ObjectOrientedProgramming.Lab4.Context;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public interface ICommand
{
    public string Name { get; }
    void Execute(FileSystemContext context);
}