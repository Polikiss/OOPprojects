namespace Itmo.ObjectOrientedProgramming.Lab2.HardDrive;

public interface IHardDriveBuilder
{
    public IHardDriveBuilder WithCapacityInGb(uint capacityInGb);
    public IHardDriveBuilder WithSpindleSpeed(uint spindSpeed);
    public IHardDriveBuilder WithPowerConsumption(uint powerConsumption);
    public HardDrive BuildHardDrive();
}