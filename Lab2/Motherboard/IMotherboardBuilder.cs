using Itmo.ObjectOrientedProgramming.Lab2.BIOS;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public interface IMotherboardBuilder
{
    public IMotherboardBuilder WithSocket(string manufacturer, string name);
    public IMotherboardBuilder WithWiFiAdapter();
    public IMotherboardBuilder WithAmountPcieLines(byte amountPcieLines);
    public IMotherboardBuilder WithAmountSataPorts(byte amountSataPorts);
    public IMotherboardBuilder WithDdrStandard(double ddrStandard);
    public IMotherboardBuilder WithAmountRamSlots(byte amountRamSlots);
    public IMotherboardBuilder WithFormFactor(FormFactor formFactor);
    public IMotherboardBuilder WithBios(IBios bios);
    public MotherBoard BuildMotherBoard();
}