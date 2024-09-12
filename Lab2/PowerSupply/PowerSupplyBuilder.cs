namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public class PowerSupplyBuilder : IPowerSupplyBuilder
{
    private double _peakLoad;
    public IPowerSupplyBuilder WithPeakLoad(double peakLoad)
    {
        _peakLoad = peakLoad;
        return this;
    }

    public IPowerSupply BuildPowerSupply()
    {
        return new PowerSupply(_peakLoad);
    }
}