namespace Itmo.ObjectOrientedProgramming.Lab2.XMPProfile;

public interface IXmpProfileBuilder
{
    public IXmpProfileBuilder WithTimings(uint first, uint second, uint third, uint fourth);
    public IXmpProfileBuilder WithTimings(Timings? timings);
    public IXmpProfileBuilder WithVoltage(double voltage);
    public IXmpProfileBuilder WithFrequency(uint frequency);
    public XmpProfile BuildXmpProfile();
}