namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public class VideoCard : IVideoCard
{
    public VideoCard(WidthAndHigh widthAndHigh, uint videoStorageCapacity, double pcieVersion, double chipFrequency, uint powerConsumption)
    {
        WidthAndHigh = widthAndHigh;
        VideoStorageCapacity = videoStorageCapacity;
        PowerConsumption = powerConsumption;
        PcieVersion = pcieVersion;
        ChipFrequency = chipFrequency;
    }

    public WidthAndHigh WidthAndHigh { get; }
    public uint VideoStorageCapacity { get; }
    public double PcieVersion { get; }
    public double ChipFrequency { get; }
    public uint PowerConsumption { get; }
}