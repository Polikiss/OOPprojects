namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter;

public class WiFiAdapterDirect : IWiFiAdapterDirect
{
    private readonly IWiFiAdapterBuilder _builder;

    public WiFiAdapterDirect(IWiFiAdapterBuilder builder)
    {
        _builder = builder;
    }

    public IWiFiAdapterBuilder DirectDexp()
    {
        _builder.WithPowerConsumption(50);
        _builder.WithBluetoothModule();
        _builder.WithWiFiStandardVersion(4);
        _builder.WithPciE(5);

        return _builder;
    }
}