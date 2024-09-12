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

public class Computer : IComputer
{
    public Computer(
        IComputerCase computerCase,
        IRam ram,
        IHardDrive? hardDrive,
        IMotherboard motherboard,
        IPowerSupply powerSupply,
        IProcessor processor,
        IProcessorCoolingSystem processorCoolingSystem,
        ISsdDrive? ssdDrive,
        IVideoCard? videoCard,
        IWiFiAdapter? wiFiAdapter)
    {
        ComputerCase = computerCase;
        Ram = ram;
        HardDrive = hardDrive;
        MotherBoard = motherboard;
        PowerSupply = powerSupply;
        Processor = processor;
        ProcessorCoolingSystem = processorCoolingSystem;
        SsdDrive = ssdDrive;
        VideoCard = videoCard;
        WiFiAdapter = wiFiAdapter;
    }

    public IComputerCase ComputerCase { get; }
    public IRam Ram { get; }
    public IHardDrive? HardDrive { get; }
    public IMotherboard MotherBoard { get; }
    public IPowerSupply PowerSupply { get; }
    public IProcessor Processor { get; }
    public IProcessorCoolingSystem ProcessorCoolingSystem { get; }
    public ISsdDrive? SsdDrive { get; }
    public IVideoCard? VideoCard { get; }
    public IWiFiAdapter? WiFiAdapter { get; }
}