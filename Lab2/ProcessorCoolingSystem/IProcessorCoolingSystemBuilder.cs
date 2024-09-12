using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;

public interface IProcessorCoolingSystemBuilder
{
    public IProcessorCoolingSystemBuilder WithTdp(byte tdp);
    public IProcessorCoolingSystemBuilder WithSupportedSocketList(IList<Socket.Socket> supportedSocketList);
    public IProcessorCoolingSystemBuilder AddSupportedSocket(Socket.Socket socket);
    public IProcessorCoolingSystemBuilder WithDimension(uint high, uint width, uint length);
    public IProcessorCoolingSystemBuilder WithDimension(Dimension dimension);
    public ProcessorCoolingSystem BuildProcessorCoolingSystem();
}