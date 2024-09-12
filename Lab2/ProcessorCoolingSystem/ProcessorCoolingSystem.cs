using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;

public class ProcessorCoolingSystem : IProcessorCoolingSystem
{
    public ProcessorCoolingSystem(byte tdp, IList<Socket.Socket> supportedSocketList, Dimension dimension)
    {
        Tdp = tdp;
        SupportedSocketList = supportedSocketList;
        Dimension = dimension;
    }

    public byte Tdp { get; }
    public IList<Socket.Socket> SupportedSocketList { get; }
    public Dimension Dimension { get; }
}