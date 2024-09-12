using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.SSDDrive;

public interface ISsdDrive : IComputerComponent
{
    public ConnectionOption ConnectionOption { get; }
    public uint CapacityInGb { get; }
    public uint MaximumSpeedOf { get; }
    public uint PowerConsumption { get; }
}