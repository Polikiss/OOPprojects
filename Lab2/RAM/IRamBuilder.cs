using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.XMPProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public interface IRamBuilder
{
    public IRamBuilder WithAvailableMemorySize(ushort availableMemorySize);
    public IRamBuilder WithFormFactor(FormFactorRam? formFactor);
    public IRamBuilder WithFormFactor(string name);
    public IRamBuilder WithDdrStandardVersion(double ddrStandardVersion);
    public IRamBuilder WithPowerConsumption(ushort powerConsumption);

    public IRamBuilder WithSupportedFrequency(int supportedFrequency);
    public IRamBuilder WithSupportedVoltage(double supportedVoltage);

    public IRamBuilder WithAvailableXmpDocppProfiles(IList<IXmpProfile> availableXmpDocppProfiles);

    public IRamBuilder AddXmpDocppProfile(IXmpProfile xmpDocpProfiles);
    public Ram BuildRam();
}