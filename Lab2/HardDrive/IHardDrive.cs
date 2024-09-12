using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.HardDrive;

public interface IHardDrive : IComputerComponent
{
    public uint CapacityInGb { get; }
    public uint SpindleSpeed { get; }
    public uint PowerConsumption { get; }
}