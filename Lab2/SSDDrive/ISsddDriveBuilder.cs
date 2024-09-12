namespace Itmo.ObjectOrientedProgramming.Lab2.SSDDrive;

public interface ISsddDriveBuilder
{
    public ISsddDriveBuilder WithConnectionOption(ConnectionOption? connectionOption);
    public ISsddDriveBuilder WithCapacityInGb(uint capacityInGb);
    public ISsddDriveBuilder WithMaximumSpeedOf(uint maximumSpeedOf);
    public ISsddDriveBuilder WithPowerConsumption(uint powerConsumption);
    public SSDDrive BuildSsdDrive();
}