namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public class VideoCardDirect : IVideoCardDirect
{
    private readonly IVideoCardBuilder _builder;

    public VideoCardDirect(IVideoCardBuilder builder)
    {
        _builder = builder;
    }

    public IVideoCardBuilder Direct()
    {
        _builder.WithChipFrequency(1.2);
        _builder.WithPcieVersion(2);
        _builder.WithPowerConsumption(60);
        _builder.WithWidthAndHigh(60, 60);
        _builder.WithVideoStorageCapacity(200);

        return _builder;
    }
}