namespace Itmo.ObjectOrientedProgramming.Lab2.XMPProfile;

public class XmpProfileDirect : IXmpProfileDirect
{
    private readonly IXmpProfileBuilder _builder;

    public XmpProfileDirect(IXmpProfileBuilder builder)
    {
        _builder = builder;
    }

    public IXmpProfileBuilder Direct()
    {
        _builder.WithFrequency(1200);
        _builder.WithTimings(11, 11, 11, 28);
        _builder.WithVoltage(1.5);
        return _builder;
    }
}