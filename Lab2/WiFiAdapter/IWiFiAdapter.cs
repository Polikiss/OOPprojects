using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter;

public interface IWiFiAdapter : IComputerComponent
{
    public double WiFiStandardVersion { get; }
    public BuiltInBluetoothModule? BluetoothModule { get; }
    public double PciE { get; }
    public uint PowerConsumption { get; }
}