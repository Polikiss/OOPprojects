using Itmo.ObjectOrientedProgramming.Lab2.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public interface IMotherboard : IComputerComponent
{
    public Socket.Socket Socket { get; }
    public BuiltInWiFiAdapter? WiFiAdapter { get; }
    public byte AmountPcieLines { get; }
    public byte AmountSataPorts { get; }
    public double DdrStandard { get; }
    public byte AmountRamSlots { get; }
    public FormFactor FormFactor { get; }
    public IBios Bios { get; }
}