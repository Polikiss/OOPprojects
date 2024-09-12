using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.XMPProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public class Ram : IRam
{
    public Ram(ushort availableMemorySize, FormFactorRam formFactor, double ddrStandardVersion, ushort powerConsumption, int supportedFrequency, double supportedVoltage, IList<IXmpProfile> availableXmpDocppProfiles)
    {
        AvailableMemorySize = availableMemorySize;
        FormFactor = formFactor;
        DdrStandardVersion = ddrStandardVersion;
        PowerConsumption = powerConsumption;
        SupportedFrequency = supportedFrequency;
        SupportedVoltage = supportedVoltage;
        AvailableXmpDocppProfiles = availableXmpDocppProfiles;
    }

    public ushort AvailableMemorySize { get; }
    public FormFactorRam FormFactor { get; }
    public double DdrStandardVersion { get; }
    public ushort PowerConsumption { get; }
    public int SupportedFrequency { get; }
    public double SupportedVoltage { get; }
    public IList<IXmpProfile> AvailableXmpDocppProfiles { get; }
}