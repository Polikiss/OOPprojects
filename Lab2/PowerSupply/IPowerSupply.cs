using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public interface IPowerSupply : IComputerComponent
{
    public double PeakLoad { get; }
}