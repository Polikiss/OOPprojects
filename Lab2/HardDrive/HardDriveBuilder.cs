namespace Itmo.ObjectOrientedProgramming.Lab2.HardDrive;

public class HardDriveBuilder : IHardDriveBuilder
{
    private uint _capacityInGb;
    private uint _spindleSpeed;
    private uint _powerConsumption;
    public IHardDriveBuilder WithCapacityInGb(uint capacityInGb)
    {
        _capacityInGb = capacityInGb;
        return this;
    }

    public IHardDriveBuilder WithSpindleSpeed(uint spindSpeed)
    {
        _spindleSpeed = spindSpeed;
        return this;
    }

    public IHardDriveBuilder WithPowerConsumption(uint powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public HardDrive BuildHardDrive()
    {
        return new HardDrive(_capacityInGb, _spindleSpeed, _powerConsumption);
    }
}