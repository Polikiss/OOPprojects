namespace Itmo.ObjectOrientedProgramming.Lab2.XMPProfile;

public class XmpProfileBuilder : IXmpProfileBuilder
{
    private Timings? _timings;
    private double _voltage;
    private uint _frequency;
    public IXmpProfileBuilder WithTimings(uint first, uint second, uint third, uint fourth)
    {
        _timings = new Timings(first, second, third, fourth);
        return this;
    }

    public IXmpProfileBuilder WithTimings(Timings? timings)
    {
        _timings = timings;
        return this;
    }

    public IXmpProfileBuilder WithVoltage(double voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IXmpProfileBuilder WithFrequency(uint frequency)
    {
        _frequency = frequency;
        return this;
    }

    public XmpProfile BuildXmpProfile()
    {
        return new XmpProfile(_timings, _voltage, _frequency);
    }
}