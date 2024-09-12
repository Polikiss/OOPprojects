namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter;

public class WiFiAdapterBuilder : IWiFiAdapterBuilder
{
    private double _wiFiStandardVersion;
    private BuiltInBluetoothModule? _bluetoothModule;
    private double _pciE;
    private uint _powerConsumption;
    public IWiFiAdapterBuilder WithWiFiStandardVersion(double wiFiStandardVersion)
    {
        _wiFiStandardVersion = wiFiStandardVersion;
        return this;
    }

    public IWiFiAdapterBuilder WithBluetoothModule()
    {
        _bluetoothModule = new BuiltInBluetoothModule();
        return this;
    }

    public IWiFiAdapterBuilder WithPciE(double pciE)
    {
        _pciE = pciE;
        return this;
    }

    public IWiFiAdapterBuilder WithPowerConsumption(uint powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WiFiAdapter BuildWiFiAdapter()
    {
        return new WiFiAdapter(_wiFiStandardVersion, _bluetoothModule, _pciE, _powerConsumption);
    }
}