namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter;

public class WiFiAdapter : IWiFiAdapter
{
    public WiFiAdapter(double wiFiStandardVersion, BuiltInBluetoothModule? bluetoothModule, double pciE, uint powerConsumption)
    {
        WiFiStandardVersion = wiFiStandardVersion;
        BluetoothModule = bluetoothModule;
        PciE = pciE;
        PowerConsumption = powerConsumption;
    }

    public double WiFiStandardVersion { get; }
    public BuiltInBluetoothModule? BluetoothModule { get; }
    public double PciE { get; }
    public uint PowerConsumption { get; }
}