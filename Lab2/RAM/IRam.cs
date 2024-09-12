using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Component;
using Itmo.ObjectOrientedProgramming.Lab2.XMPProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public interface IRam : IComputerComponent
{
    public ushort AvailableMemorySize { get; }
    public FormFactorRam FormFactor { get; }
    public double DdrStandardVersion { get; }
    public ushort PowerConsumption { get; }
    public int SupportedFrequency { get; }
    public double SupportedVoltage { get; }
    public IList<IXmpProfile> AvailableXmpDocppProfiles { get; }
}
