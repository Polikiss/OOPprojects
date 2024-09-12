namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public interface IVideoCardBuilder
{
    public IVideoCardBuilder WithWidthAndHigh(uint high, uint width);
    public IVideoCardBuilder WithWidthAndHigh(WidthAndHigh? widthAndHigh);
    public IVideoCardBuilder WithVideoStorageCapacity(uint videoStorageCapacity);
    public IVideoCardBuilder WithPcieVersion(double pcieVersion);
    public IVideoCardBuilder WithChipFrequency(double chipFrequency);
    public IVideoCardBuilder WithPowerConsumption(uint powerConsumption);
    public VideoCard BuildVideoCard();
}