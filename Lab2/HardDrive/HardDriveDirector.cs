namespace Itmo.ObjectOrientedProgramming.Lab2.HardDrive;

public class HardDriveDirector : IHardDriveDirector
{
    private readonly IHardDriveBuilder _builder;

    public HardDriveDirector(IHardDriveBuilder builder)
    {
        _builder = builder;
    }

    public IHardDriveBuilder Direct()
    {
        _builder.WithPowerConsumption(120);
        _builder.WithSpindleSpeed(7200);
        _builder.WithCapacityInGb(1000);

        return _builder;
    }
}