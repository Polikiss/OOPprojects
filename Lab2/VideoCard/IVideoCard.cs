using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public interface IVideoCard : IComputerComponent
{
    public WidthAndHigh WidthAndHigh { get; }
    public uint VideoStorageCapacity { get; }
    public double PcieVersion { get; }
    public double ChipFrequency { get; }
    public uint PowerConsumption { get; }
}