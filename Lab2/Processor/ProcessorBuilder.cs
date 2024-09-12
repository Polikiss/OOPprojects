using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public class ProcessorBuilder : IProcessorBuilder
{
    private Socket.Socket? _socket;
    private double _coreFrequency;
    private byte _amountCores;
    private BuiltInVideoCore? _builtInVideoCore;
    private byte _tdp;
    private byte _powerConsumption;
    public IProcessorBuilder WithSocket(string manufacturer, string name)
    {
        _socket = new Socket.Socket(manufacturer, name);
        return this;
    }

    public IProcessorBuilder WithSocket(Socket.Socket? socket)
    {
        _socket = socket;
        return this;
    }

    public IProcessorBuilder WithCoreFrequency(double coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public IProcessorBuilder WithAmountCores(byte amountCores)
    {
        _amountCores = amountCores;
        return this;
    }

    public IProcessorBuilder WithBuiltInVideoCore()
    {
        _builtInVideoCore = new BuiltInVideoCore();
        return this;
    }

    public IProcessorBuilder WithTdp(byte tdp)
    {
        _tdp = tdp;
        return this;
    }

    public IProcessorBuilder WithPowerConsumption(byte powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IProcessor BuildProcessor()
    {
        return new Processor(_socket ?? throw new MissingMemberException(), _coreFrequency, _amountCores, _builtInVideoCore, _tdp, _powerConsumption);
    }
}