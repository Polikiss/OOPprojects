namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public class PowerSupplyDirect : IPowerSupplyDirect
{
    private IPowerSupplyBuilder _builder;

    public PowerSupplyDirect(IPowerSupplyBuilder builder)
    {
        _builder = builder;
    }

    public IPowerSupplyBuilder Direct()
    {
        _builder.WithPeakLoad(300);
        return _builder;
    }
}