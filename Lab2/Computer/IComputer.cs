using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.SSDDrive;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer;

public interface IComputer
{
    public IComputerCase? ComputerCase { get; }
    public IRam? Ram { get; }
    public IHardDrive? HardDrive { get; }
    public IMotherboard? MotherBoard { get; }
    public IPowerSupply? PowerSupply { get; }
    public IProcessor? Processor { get; }
    public IProcessorCoolingSystem? ProcessorCoolingSystem { get; }
    public ISsdDrive? SsdDrive { get; }
    public IVideoCard? VideoCard { get; }
    public IWiFiAdapter? WiFiAdapter { get; }
}