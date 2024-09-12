using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validation;

public class ComputerCaseValidation : IComputerValidation
{
    public AssemblyResult Validation(ValidationModel validationModel)
    {
        if (validationModel.VideoCard is not null)
        {
            if (validationModel.ComputerCase.MaxWidthAndHighVideoCard?.High < validationModel.VideoCard.WidthAndHigh?.High)
            {
                return new AssemblyResult.Fail();
            }

            if (validationModel.ComputerCase.MaxWidthAndHighVideoCard?.Width < validationModel.VideoCard.WidthAndHigh?.Width)
            {
               return new AssemblyResult.Fail();
            }
        }

        if (validationModel.ComputerCase.Dimension?.High < validationModel.ProcessorCoolingSystem?.Dimension?.High)
        {
            return new AssemblyResult.Fail();
        }

        if (validationModel.ComputerCase.Dimension?.Width < validationModel.ProcessorCoolingSystem?.Dimension?.Width)
        {
            return new AssemblyResult.Fail();
        }

        if (validationModel.ComputerCase.Dimension?.Lenght < validationModel.ProcessorCoolingSystem?.Dimension?.Lenght)
        {
            return new AssemblyResult.Fail();
        }

        return new AssemblyResult.Success();
    }
}