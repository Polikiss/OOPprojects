namespace Itmo.ObjectOrientedProgramming.Lab2.SSDDrive;

public class SSDDrive : ISsdDrive
{
    public SSDDrive(ConnectionOption connectionOption, uint capacityInGb, uint maximumSpeedOf, uint powerConsumption)
    {
        ConnectionOption = connectionOption;
        CapacityInGb = capacityInGb;
        MaximumSpeedOf = maximumSpeedOf;
        PowerConsumption = powerConsumption;
    }

    public ConnectionOption ConnectionOption { get; }
    public uint CapacityInGb { get; }
    public uint MaximumSpeedOf { get; }
    public uint PowerConsumption { get; }
}