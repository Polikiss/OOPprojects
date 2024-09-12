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

namespace Itmo.ObjectOrientedProgramming.Lab2.Validation;

public record ValidationModel(IComputerCase ComputerCase,
    IRam Ram,
    IHardDrive? HardDrive,
    IMotherboard Motherboard,
    IPowerSupply PowerSupply,
    IProcessor Processor,
    IProcessorCoolingSystem ProcessorCoolingSystem,
    ISsdDrive? SsdDrive,
    IVideoCard? VideoCard,
    IWiFiAdapter? WiFiAdapter);