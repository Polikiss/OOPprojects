using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Result;
using Itmo.ObjectOrientedProgramming.Lab2.SSDDrive;
using Itmo.ObjectOrientedProgramming.Lab2.Validation;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer;

public class ComputerBuilder : IComputerBuilder
{
    private IList<IComputerValidation> _computerValidations;
    private IComputerCase? _computerCase;
    private IRam? _ram;
    private IHardDrive? _hardDrive;
    private IMotherboard? _motherBoard;
    private IPowerSupply? _powerSupply;
    private IProcessor? _processor;
    private IProcessorCoolingSystem? _processorCoolingSystem;
    private ISsdDrive? _ssdDrive;
    private IVideoCard? _videoCard;
    private IWiFiAdapter? _wiFiAdapter;
    private ValidationModel? _validationModel;

    public ComputerBuilder(IList<IComputerValidation> computerValidations)
    {
        _computerValidations = computerValidations;
    }

    public IComputerBuilder WithComputerCase(IComputerCase computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public IComputerBuilder WithRam(IRam ram)
    {
        _ram = ram;
        return this;
    }

    public IComputerBuilder WithHardDrive(IHardDrive? hardDrive)
    {
        _hardDrive = hardDrive;
        return this;
    }

    public IComputerBuilder WithMotherBoard(IMotherboard motherBoard)
    {
        _motherBoard = motherBoard;
        return this;
    }

    public IComputerBuilder WithPowerSupply(IPowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public IComputerBuilder WithProcessor(IProcessor processor)
    {
        _processor = processor;
        return this;
    }

    public IComputerBuilder WithProcessorCoolingSystem(IProcessorCoolingSystem processorCoolingSystem)
    {
        _processorCoolingSystem = processorCoolingSystem;
        return this;
    }

    public IComputerBuilder WithSsdDrive(ISsdDrive? ssdDrive)
    {
        _ssdDrive = ssdDrive;
        return this;
    }

    public IComputerBuilder WithVideoCard(IVideoCard? videoCard)
    {
        _videoCard = videoCard;
        return this;
    }

    public IComputerBuilder WithWiFiAdapter(IWiFiAdapter? wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }

    public AssemblyResult BuildComputer()
    {
        if (_computerCase is null || _ram is null || _motherBoard is null || _powerSupply is null ||
            _processor is null || _processorCoolingSystem is null) return new AssemblyResult.FailNotEnoughComponent();
        _validationModel = new ValidationModel(_computerCase, _ram, _hardDrive, _motherBoard, _powerSupply, _processor, _processorCoolingSystem, _ssdDrive, _videoCard, _wiFiAdapter);
        AssemblyResult result;
        foreach (IComputerValidation varComputerValidation in _computerValidations)
        {
            result = varComputerValidation.Validation(_validationModel);
            if (result is not AssemblyResult.Success)
            {
                return result;
            }
        }

        return new AssemblyResult.AssemblySuccess(new Computer(_validationModel.ComputerCase, _validationModel.Ram, _validationModel.HardDrive, _validationModel.Motherboard, _validationModel.PowerSupply, _validationModel.Processor, _validationModel.ProcessorCoolingSystem, _validationModel.SsdDrive, _validationModel.VideoCard, _validationModel.WiFiAdapter));
    }
}