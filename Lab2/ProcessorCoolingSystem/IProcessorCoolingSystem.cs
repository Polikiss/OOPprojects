using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;

public interface IProcessorCoolingSystem : IComputerComponent
{
    public byte Tdp { get; }
    public IList<Socket.Socket> SupportedSocketList { get; }
    public Dimension Dimension { get; }
}