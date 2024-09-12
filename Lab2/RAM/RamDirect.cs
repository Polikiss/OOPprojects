using Itmo.ObjectOrientedProgramming.Lab2.XMPProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public class RamDirect : IRamDirect
{
    private IRamBuilder _builder;

    public RamDirect(IRamBuilder builder)
    {
        _builder = builder;
    }

    public IRamBuilder Direct()
    {
        _builder.WithPowerConsumption(120);
        _builder.WithFormFactor("DIMM");
        _builder.WithDdrStandardVersion(3);
        _builder.WithAvailableMemorySize(4);

        IXmpProfileBuilder xmpProfileBuilder = new XmpProfileBuilder();
        var xmpProfileDirect = new XmpProfileDirect(xmpProfileBuilder);
        xmpProfileBuilder = xmpProfileDirect.Direct();
        IXmpProfile xmpProfile = xmpProfileBuilder.BuildXmpProfile();
        _builder.AddXmpDocppProfile(xmpProfile);
        return _builder;
    }
}