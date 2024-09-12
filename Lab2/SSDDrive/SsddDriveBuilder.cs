using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.SSDDrive;

public class SsddDriveBuilder : ISsddDriveBuilder
{
    private ConnectionOption? _connectionOption;
    private uint _capacityInGb;
    private uint _maximumSpeedOf;
    private uint _powerConsumption;
    public ISsddDriveBuilder WithConnectionOption(ConnectionOption? connectionOption)
    {
        _connectionOption = connectionOption;
        return this;
    }

    public ISsddDriveBuilder WithCapacityInGb(uint capacityInGb)
    {
        _capacityInGb = capacityInGb;
        return this;
    }

    public ISsddDriveBuilder WithMaximumSpeedOf(uint maximumSpeedOf)
    {
        _maximumSpeedOf = maximumSpeedOf;
        return this;
    }

    public ISsddDriveBuilder WithPowerConsumption(uint powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public SSDDrive BuildSsdDrive()
    {
        return new SSDDrive(_connectionOption ?? throw new MissingMemberException(), _capacityInGb, _maximumSpeedOf, _powerConsumption);
    }
}