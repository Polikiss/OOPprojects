namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public class PowerSupply : IPowerSupply
{
    public PowerSupply(double peakLoad)
    {
        PeakLoad = peakLoad;
    }

    public double PeakLoad { get; }
}