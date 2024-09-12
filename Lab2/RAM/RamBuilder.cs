using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.XMPProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public class RamBuilder : IRamBuilder
{
    private ushort _availableMemorySize;
    private FormFactorRam? _formFactor;
    private double _ddrStandardVersion;
    private ushort _powerConsumption;
    private int _supportedFrequency;
    private double _supportedVoltage;
    private IList<IXmpProfile>? _availableXmpDocppProfiles = new List<IXmpProfile>();
    public IRamBuilder WithAvailableMemorySize(ushort availableMemorySize)
    {
        _availableMemorySize = availableMemorySize;
        return this;
    }

    public IRamBuilder WithFormFactor(FormFactorRam? formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRamBuilder WithFormFactor(string name)
    {
        _formFactor = new FormFactorRam(name);
        return this;
    }

    public IRamBuilder WithDdrStandardVersion(double ddrStandardVersion)
    {
        _ddrStandardVersion = ddrStandardVersion;
        return this;
    }

    public IRamBuilder WithPowerConsumption(ushort powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IRamBuilder WithSupportedFrequency(int supportedFrequency)
    {
        _supportedFrequency = supportedFrequency;
        return this;
    }

    public IRamBuilder WithSupportedVoltage(double supportedVoltage)
    {
        _supportedVoltage = supportedVoltage;
        return this;
    }

    public IRamBuilder WithAvailableXmpDocppProfiles(IList<IXmpProfile> availableXmpDocppProfiles)
    {
        _availableXmpDocppProfiles = availableXmpDocppProfiles;
        return this;
    }

    public IRamBuilder AddXmpDocppProfile(IXmpProfile xmpDocpProfiles)
    {
        _availableXmpDocppProfiles?.Add(xmpDocpProfiles);
        return this;
    }

    public Ram BuildRam()
    {
        return new Ram(
            _availableMemorySize,
            _formFactor ?? throw new MissingMemberException(),
            _ddrStandardVersion,
            _powerConsumption,
            _supportedFrequency,
            _supportedVoltage,
            _availableXmpDocppProfiles ?? throw new MissingMemberException());
    }
}