using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Validation;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerTest
{
    [Fact]
    public void SuccessComputerAssembly()
    {
        IProcessor processor = StandardProcessor();
        IMotherboard motherboard = StandardMotherboard();
        IProcessorCoolingSystem processorCoolingSystem = StandardProcessorCoolingSystem();
        IComputerCase computerCase = StandardComputerCase();
        IRam ram = StandardRam();
        IHardDrive hardDrive = StandardHardDrive();
        IPowerSupply powerSupply = StandardPowerSupply();
        IVideoCard videoCard = StandardVideoCard();

        IList<IComputerValidation> computerValidations = StandardValidation();

        IComputerBuilder computerBuilder = new ComputerBuilder(computerValidations);
        computerBuilder.WithComputerCase(computerCase);
        computerBuilder.WithRam(ram);
        computerBuilder.WithProcessor(processor);
        computerBuilder.WithHardDrive(hardDrive);
        computerBuilder.WithMotherBoard(motherboard);
        computerBuilder.WithPowerSupply(powerSupply);
        computerBuilder.WithVideoCard(videoCard);
        computerBuilder.WithProcessorCoolingSystem(processorCoolingSystem);

        AssemblyResult result = computerBuilder.BuildComputer();

        Assert.IsType<AssemblyResult.AssemblySuccess>(result);
    }

    [Fact]
    public void FailMissingComponentWiFi()
    {
        IProcessor processor = StandardProcessor();

        IMotherboardBuilder motherboardBuilder = new MotherboardBuilder();
        var motherboardDirector = new MotherboardDirect(motherboardBuilder);
        motherboardBuilder = motherboardDirector.Direct();
        IMotherboard motherboard = motherboardBuilder.BuildMotherBoard();

        IProcessorCoolingSystem processorCoolingSystem = StandardProcessorCoolingSystem();
        IComputerCase computerCase = StandardComputerCase();
        IRam ram = StandardRam();
        IHardDrive hardDrive = StandardHardDrive();
        IPowerSupply powerSupply = StandardPowerSupply();
        IVideoCard videoCard = StandardVideoCard();

        IList<IComputerValidation> computerValidations = StandardValidation();

        IComputerBuilder computerBuilder = new ComputerBuilder(computerValidations);
        computerBuilder.WithComputerCase(computerCase);
        computerBuilder.WithRam(ram);
        computerBuilder.WithProcessor(processor);
        computerBuilder.WithHardDrive(hardDrive);
        computerBuilder.WithMotherBoard(motherboard);
        computerBuilder.WithPowerSupply(powerSupply);
        computerBuilder.WithVideoCard(videoCard);
        computerBuilder.WithProcessorCoolingSystem(processorCoolingSystem);

        AssemblyResult result = computerBuilder.BuildComputer();

        Assert.IsType<AssemblyResult.Fail>(result);
    }

    [Fact]
    public void SuccessWithNoGuaranty()
    {
        IProcessor processor = StandardProcessor();
        IMotherboard motherboard = StandardMotherboard();
        IProcessorCoolingSystem processorCoolingSystem = StandardProcessorCoolingSystem();
        IComputerCase computerCase = StandardComputerCase();
        IRam ram = StandardRam();
        IHardDrive hardDrive = StandardHardDrive();

        IPowerSupplyBuilder powerSupplyBuilder = new PowerSupplyBuilder();
        powerSupplyBuilder = powerSupplyBuilder.WithPeakLoad(120);
        IPowerSupply powerSupply = powerSupplyBuilder.BuildPowerSupply();

        IVideoCard videoCard = StandardVideoCard();

        IList<IComputerValidation> computerValidations = StandardValidation();

        IComputerBuilder computerBuilder = new ComputerBuilder(computerValidations);
        computerBuilder.WithComputerCase(computerCase);
        computerBuilder.WithRam(ram);
        computerBuilder.WithProcessor(processor);
        computerBuilder.WithHardDrive(hardDrive);
        computerBuilder.WithMotherBoard(motherboard);
        computerBuilder.WithPowerSupply(powerSupply);
        computerBuilder.WithVideoCard(videoCard);
        computerBuilder.WithProcessorCoolingSystem(processorCoolingSystem);

        AssemblyResult result = computerBuilder.BuildComputer();

        Assert.IsType<AssemblyResult.SuccessWithWarning>(result);
    }

    [Fact]
    public void WeakCoolerSystem()
    {
        IProcessorBuilder processorBuilder = new ProcessorBuilder();
        var processorDirector = new ProcessorDirect(processorBuilder);
        processorBuilder.WithTdp(120);
        processorBuilder = processorDirector.Direct();
        IProcessor processor = processorBuilder.BuildProcessor();

        IMotherboard motherboard = StandardMotherboard();

        IProcessorCoolingSystemBuilder processorCoolingSystemBuilder = new ProcessorCoolingSystemBuilder();
        var processorCoolingSystemDirector = new ProcessorCoolingSystemDirect(processorCoolingSystemBuilder);
        processorCoolingSystemBuilder = processorCoolingSystemDirector.Direct();
        processorCoolingSystemBuilder.WithTdp(55);
        IProcessorCoolingSystem processorCoolingSystem = processorCoolingSystemBuilder.BuildProcessorCoolingSystem();

        IComputerCase computerCase = StandardComputerCase();
        IRam ram = StandardRam();
        IHardDrive hardDrive = StandardHardDrive();
        IPowerSupply powerSupply = StandardPowerSupply();
        IVideoCard videoCard = StandardVideoCard();

        IList<IComputerValidation> computerValidations = StandardValidation();

        IComputerBuilder computerBuilder = new ComputerBuilder(computerValidations);
        computerBuilder.WithComputerCase(computerCase);
        computerBuilder.WithRam(ram);
        computerBuilder.WithProcessor(processor);
        computerBuilder.WithHardDrive(hardDrive);
        computerBuilder.WithMotherBoard(motherboard);
        computerBuilder.WithPowerSupply(powerSupply);
        computerBuilder.WithVideoCard(videoCard);
        computerBuilder.WithProcessorCoolingSystem(processorCoolingSystem);

        AssemblyResult result = computerBuilder.BuildComputer();
        Assert.IsType<AssemblyResult.SuccessWithWarning>(result);
    }

    private static IProcessor StandardProcessor()
    {
        IProcessorBuilder processorBuilder = new ProcessorBuilder();
        var processorDirector = new ProcessorDirect(processorBuilder);
        processorBuilder = processorDirector.Direct();
        IProcessor processor = processorBuilder.BuildProcessor();
        return processor;
    }

    private static IMotherboard StandardMotherboard()
    {
        IMotherboardBuilder motherboardBuilder = new MotherboardBuilder();
        var motherboardDirector = new MotherboardDirect(motherboardBuilder);
        motherboardBuilder = motherboardDirector.Direct();
        motherboardBuilder.WithWiFiAdapter();
        IMotherboard motherboard = motherboardBuilder.BuildMotherBoard();
        return motherboard;
    }

    private static IComputerCase StandardComputerCase()
    {
        IComputerCaseBuilder computerCaseBuilder = new ComputerCaseBuilder();
        var computerCaseDirector = new ComputerCaseDirect(computerCaseBuilder);
        computerCaseBuilder = computerCaseDirector.Direct();
        IComputerCase computerCase = computerCaseBuilder.Build();
        return computerCase;
    }

    private static IProcessorCoolingSystem StandardProcessorCoolingSystem()
    {
        IProcessorCoolingSystemBuilder processorCoolingSystemBuilder = new ProcessorCoolingSystemBuilder();
        var processorCoolingSystemDirector = new ProcessorCoolingSystemDirect(processorCoolingSystemBuilder);
        processorCoolingSystemBuilder = processorCoolingSystemDirector.Direct();
        IProcessorCoolingSystem processorCoolingSystem = processorCoolingSystemBuilder.BuildProcessorCoolingSystem();
        return processorCoolingSystem;
    }

    private static IRam StandardRam()
    {
        IRamBuilder ramBuilder = new RamBuilder();
        IRamDirect ramDirect = new RamDirect(ramBuilder);
        ramBuilder = ramDirect.Direct();
        IRam ram = ramBuilder.BuildRam();
        return ram;
    }

    private static IHardDrive StandardHardDrive()
    {
        IHardDriveBuilder hardDriveBuilder = new HardDriveBuilder();
        IHardDriveDirector hardDriveDirector = new HardDriveDirector(hardDriveBuilder);
        hardDriveBuilder = hardDriveDirector.Direct();
        IHardDrive hardDrive = hardDriveBuilder.BuildHardDrive();
        return hardDrive;
    }

    private static IPowerSupply StandardPowerSupply()
    {
        IPowerSupplyBuilder powerSupplyBuilder = new PowerSupplyBuilder();
        IPowerSupplyDirect powerSupplyDirector = new PowerSupplyDirect(powerSupplyBuilder);
        powerSupplyBuilder = powerSupplyDirector.Direct();
        IPowerSupply powerSupply = powerSupplyBuilder.BuildPowerSupply();
        return powerSupply;
    }

    private static IVideoCard StandardVideoCard()
    {
        IVideoCardBuilder videoCardBuilder = new VideoCardBuilder();
        IVideoCardDirect videoCardDirector = new VideoCardDirect(videoCardBuilder);
        videoCardBuilder = videoCardDirector.Direct();
        IVideoCard videoCard = videoCardBuilder.BuildVideoCard();
        return videoCard;
    }

    private static IList<IComputerValidation> StandardValidation()
    {
        IList<IComputerValidation> computerValidations = new List<IComputerValidation>();
        computerValidations.Add(new ComputerCaseValidation());
        computerValidations.Add(new ProcessorValidation());
        computerValidations.Add(new MotherBoardValidation());
        computerValidations.Add(new PowerSupplyValidation());
        return computerValidations;
    }
}