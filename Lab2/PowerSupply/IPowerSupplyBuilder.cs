namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public interface IPowerSupplyBuilder
{
    public IPowerSupplyBuilder WithPeakLoad(double peakLoad);
    public IPowerSupply BuildPowerSupply();
}