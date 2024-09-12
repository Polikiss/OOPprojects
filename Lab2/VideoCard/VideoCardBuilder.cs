using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public class VideoCardBuilder : IVideoCardBuilder
{
    private WidthAndHigh? _widthAndHigh;
    private uint _videoStorageCapacity;
    private double _pcieVersion;
    private double _chipFrequency;
    private uint _powerConsumption;
    public IVideoCardBuilder WithWidthAndHigh(uint high, uint width)
    {
        _widthAndHigh = new WidthAndHigh(high, width);
        return this;
    }

    public IVideoCardBuilder WithWidthAndHigh(WidthAndHigh? widthAndHigh)
    {
        _widthAndHigh = widthAndHigh;
        return this;
    }

    public IVideoCardBuilder WithVideoStorageCapacity(uint videoStorageCapacity)
    {
        _videoStorageCapacity = videoStorageCapacity;
        return this;
    }

    public IVideoCardBuilder WithPcieVersion(double pcieVersion)
    {
        _pcieVersion = pcieVersion;
        return this;
    }

    public IVideoCardBuilder WithChipFrequency(double chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public IVideoCardBuilder WithPowerConsumption(uint powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public VideoCard BuildVideoCard()
    {
        return new VideoCard(
            _widthAndHigh ?? throw new MissingMemberException(),
            _videoStorageCapacity,
            _pcieVersion,
            _chipFrequency,
            _powerConsumption);
    }
}