using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;

public class ProcessorCoolingSystemBuilder : IProcessorCoolingSystemBuilder
{
    private byte _tdp;
    private IList<Socket.Socket>? _supportedSocketList = new List<Socket.Socket>();
    private Dimension? _dimension;
    public IProcessorCoolingSystemBuilder WithTdp(byte tdp)
    {
        _tdp = tdp;
        return this;
    }

    public IProcessorCoolingSystemBuilder WithSupportedSocketList(IList<Socket.Socket> supportedSocketList)
    {
        _supportedSocketList = supportedSocketList;
        return this;
    }

    public IProcessorCoolingSystemBuilder WithDimension(uint high, uint width, uint length)
    {
        _dimension = new Dimension(high, width, length);
        return this;
    }

    public IProcessorCoolingSystemBuilder WithDimension(Dimension dimension)
    {
        _dimension = dimension;
        return this;
    }

    public IProcessorCoolingSystemBuilder AddSupportedSocket(Socket.Socket socket)
    {
        _supportedSocketList?.Add(socket);
        return this;
    }

    public ProcessorCoolingSystem BuildProcessorCoolingSystem()
    {
        return new ProcessorCoolingSystem(
            _tdp,
            _supportedSocketList ?? throw new MissingMemberException(),
            _dimension ?? throw new MissingMemberException());
    }
}