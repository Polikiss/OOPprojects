using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validation;

public class PowerSupplyValidation : IComputerValidation
{
    public AssemblyResult Validation(ValidationModel validationModel)
    {
        AssemblyResult result = PowerSupplyValidationFail(validationModel);
        if (result is AssemblyResult.Success)
        {
            return WithoutGuarantyPowerSupplyValidation(validationModel);
        }

        return result;
    }

    private static AssemblyResult PowerSupplyValidationFail(ValidationModel validationModel)
    {
        if (validationModel.HardDrive is not null && validationModel.PowerSupply.PeakLoad < validationModel.HardDrive.PowerConsumption)
        {
            return new AssemblyResult.Fail();
        }

        if (validationModel.SsdDrive is not null && validationModel.PowerSupply.PeakLoad < validationModel.SsdDrive.PowerConsumption)
        {
            return new AssemblyResult.Fail();
        }

        if (validationModel.VideoCard is not null && validationModel.PowerSupply.PeakLoad < validationModel.VideoCard.PowerConsumption)
        {
            return new AssemblyResult.Fail();
        }

        if (validationModel.PowerSupply.PeakLoad < validationModel.Ram.PowerConsumption)
        {
            return new AssemblyResult.Fail();
        }

        if (validationModel.PowerSupply.PeakLoad < validationModel.Processor.PowerConsumption)
        {
            return new AssemblyResult.Fail();
        }

        return new AssemblyResult.Success();
    }

    private static AssemblyResult WithoutGuarantyPowerSupplyValidation(ValidationModel validationModel)
    {
        if (validationModel.HardDrive is not null &&
            validationModel.PowerSupply.PeakLoad - validationModel.HardDrive.PowerConsumption < 20)
        {
            return new AssemblyResult.SuccessWithWarning("Weak Power Supply");
        }

        if (validationModel.HardDrive is not null && validationModel.PowerSupply.PeakLoad - validationModel.HardDrive.PowerConsumption < 20)
        {
            return new AssemblyResult.SuccessWithWarning("Weak Power Supply");
        }

        if (validationModel.VideoCard is not null && validationModel.PowerSupply.PeakLoad - validationModel.VideoCard.PowerConsumption < 20)
        {
            return new AssemblyResult.SuccessWithWarning("Weak Power Supply");
        }

        if (validationModel.PowerSupply.PeakLoad - validationModel.Ram.PowerConsumption < 20)
        {
            return new AssemblyResult.SuccessWithWarning("Weak Power Supply");
        }

        if (validationModel.PowerSupply.PeakLoad - validationModel.Processor.PowerConsumption < 20)
        {
            return new AssemblyResult.SuccessWithWarning("Weak Power Supply");
        }

        return new AssemblyResult.Success();
    }
}