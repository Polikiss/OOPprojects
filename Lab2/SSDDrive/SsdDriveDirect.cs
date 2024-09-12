namespace Itmo.ObjectOrientedProgramming.Lab2.SSDDrive;

public class SsdDriveDirect : ISsdDriveDirect
{
    private readonly ISsddDriveBuilder _builder;

    public SsdDriveDirect(ISsddDriveBuilder builder)
    {
        _builder = builder;
    }

    public ISsddDriveBuilder Direct()
    {
        _builder.WithPowerConsumption(50);
        _builder.WithConnectionOption(new ConnectionOption.Sata());
        _builder.WithCapacityInGb(128);
        _builder.WithMaximumSpeedOf(400);
        return _builder;
    }
}