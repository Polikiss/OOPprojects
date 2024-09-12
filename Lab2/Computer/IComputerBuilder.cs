using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Result;
using Itmo.ObjectOrientedProgramming.Lab2.SSDDrive;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer;

public interface IComputerBuilder
{
    public IComputerBuilder WithComputerCase(IComputerCase computerCase);
    public IComputerBuilder WithRam(IRam ram);
    public IComputerBuilder WithHardDrive(IHardDrive? hardDrive);
    public IComputerBuilder WithMotherBoard(IMotherboard motherBoard);
    public IComputerBuilder WithPowerSupply(IPowerSupply powerSupply);
    public IComputerBuilder WithProcessor(IProcessor processor);
    public IComputerBuilder WithProcessorCoolingSystem(IProcessorCoolingSystem processorCoolingSystem);
    public IComputerBuilder WithSsdDrive(ISsdDrive? ssdDrive);
    public IComputerBuilder WithVideoCard(IVideoCard? videoCard);
    public IComputerBuilder WithWiFiAdapter(IWiFiAdapter? wiFiAdapter);
    public AssemblyResult BuildComputer();
}