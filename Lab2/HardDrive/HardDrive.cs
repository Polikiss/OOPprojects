namespace Itmo.ObjectOrientedProgramming.Lab2.HardDrive;

public class HardDrive : IHardDrive
{
    public HardDrive(uint capacityInGb, uint spindleSpeed, uint powerConsumption)
    {
        CapacityInGb = capacityInGb;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
    }

    public uint CapacityInGb { get; }
    public uint SpindleSpeed { get; }
    public uint PowerConsumption { get; }
}