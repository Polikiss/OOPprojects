using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.XMPProfile;

public interface IXmpProfile : IComputerComponent
{
    public Timings? Timings { get; }
    public double Voltage { get; }
    public uint Frequency { get; }
}