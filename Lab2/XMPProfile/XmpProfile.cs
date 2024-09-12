namespace Itmo.ObjectOrientedProgramming.Lab2.XMPProfile;

public class XmpProfile : IXmpProfile
{
    public XmpProfile(Timings? timings, double voltage, uint frequency)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public Timings? Timings { get; }
    public double Voltage { get; }
    public uint Frequency { get; }
}