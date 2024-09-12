namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter;

public interface IWiFiAdapterBuilder
{
    public IWiFiAdapterBuilder WithWiFiStandardVersion(double wiFiStandardVersion);
    public IWiFiAdapterBuilder WithBluetoothModule();
    public IWiFiAdapterBuilder WithPciE(double pciE);
    public IWiFiAdapterBuilder WithPowerConsumption(uint powerConsumption);
    public WiFiAdapter BuildWiFiAdapter();
}