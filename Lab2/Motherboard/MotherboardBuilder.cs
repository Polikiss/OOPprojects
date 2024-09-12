using System;
using Itmo.ObjectOrientedProgramming.Lab2.BIOS;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public class MotherboardBuilder : IMotherboardBuilder
{
    private Socket.Socket? _socket;
    private BuiltInWiFiAdapter? _wiFiAdapter;
    private byte _amountPcieLines;
    private byte _amountSataPorts;
    private double _ddrStandard;
    private byte _amountRamSlots;
    private FormFactor _formFactor;
    private IBios? _bios;

    public IMotherboardBuilder WithSocket(string manufacturer, string name)
    {
        _socket = new Socket.Socket(manufacturer, name);
        return this;
    }

    public IMotherboardBuilder WithWiFiAdapter()
    {
        _wiFiAdapter = new BuiltInWiFiAdapter();
        return this;
    }

    public IMotherboardBuilder WithAmountPcieLines(byte amountPcieLines)
    {
        _amountPcieLines = amountPcieLines;
        return this;
    }

    public IMotherboardBuilder WithAmountSataPorts(byte amountSataPorts)
    {
        _amountSataPorts = amountSataPorts;
        return this;
    }

    public IMotherboardBuilder WithDdrStandard(double ddrStandard)
    {
        _ddrStandard = ddrStandard;
        return this;
    }

    public IMotherboardBuilder WithAmountRamSlots(byte amountRamSlots)
    {
        _amountRamSlots = amountRamSlots;
        return this;
    }

    public IMotherboardBuilder WithFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherboardBuilder WithBios(IBios bios)
    {
        _bios = bios;
        return this;
    }

    public MotherBoard BuildMotherBoard()
    {
        return new MotherBoard(
            _socket ?? throw new MissingMemberException(),
            _wiFiAdapter,
            _amountPcieLines,
            _amountSataPorts,
            _ddrStandard,
            _amountRamSlots,
            _formFactor,
            _bios ?? throw new MissingMemberException());
    }
}