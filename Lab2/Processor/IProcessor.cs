using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public interface IProcessor : IComputerComponent
{
    public Socket.Socket Socket { get; }
    public double CoreFrequency { get; }
    public byte AmountCores { get; }
    public BuiltInVideoCore? BuiltInVideoCore { get; }
    public byte Tdp { get; }
    public byte PowerConsumption { get; }

    public bool Equals(IProcessor processor)
    {
        if (this.Socket != processor.Socket || this.BuiltInVideoCore != processor.BuiltInVideoCore) return false;
        if (CoreFrequency != processor.CoreFrequency || AmountCores != processor.AmountCores) return false;
        return Tdp == processor.Tdp && PowerConsumption == processor.PowerConsumption;
    }
}