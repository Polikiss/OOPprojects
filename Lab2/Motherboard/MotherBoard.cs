using Itmo.ObjectOrientedProgramming.Lab2.BIOS;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public class MotherBoard : IMotherboard
{
    public MotherBoard(Socket.Socket socket, BuiltInWiFiAdapter? builtInWiFiAdapter, byte amountPcieLines, byte amountSataPorts, double ddrStandard, byte amountRamSlots, FormFactor formFactor, IBios bios)
    {
        Socket = socket;
        WiFiAdapter = builtInWiFiAdapter;
        AmountPcieLines = amountPcieLines;
        AmountSataPorts = amountSataPorts;
        DdrStandard = ddrStandard;
        AmountRamSlots = amountRamSlots;
        FormFactor = formFactor;
        Bios = bios;
    }

    public Socket.Socket Socket { get; }
    public BuiltInWiFiAdapter? WiFiAdapter { get; }
    public byte AmountPcieLines { get; }
    public byte AmountSataPorts { get; }
    public double DdrStandard { get; }
    public byte AmountRamSlots { get; }
    public FormFactor FormFactor { get; }
    public IBios Bios { get; }
}