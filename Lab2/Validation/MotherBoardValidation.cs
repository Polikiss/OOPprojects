using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validation;

public class MotherBoardValidation : IComputerValidation
{
    public AssemblyResult Validation(ValidationModel validationModel)
    {
        if (validationModel.Motherboard.WiFiAdapter is null && validationModel.WiFiAdapter is null)
        {
            return new AssemblyResult.Fail();
        }

        if (validationModel.Motherboard.Socket != validationModel.Processor.Socket)
        {
            return new AssemblyResult.Fail();
        }

        if (validationModel.Motherboard.WiFiAdapter is null && validationModel.WiFiAdapter is null)
        {
            return new AssemblyResult.Fail();
        }

        if (validationModel.Motherboard.Bios?.SupportedProcessorList == null) return new AssemblyResult.Success();
        bool supportedProcessorsContainProcessor = false;

        foreach (IProcessor supportedProcessor in validationModel.Motherboard.Bios.SupportedProcessorList)
        {
            if (validationModel.Processor != null && validationModel.Processor.Equals(supportedProcessor))
            {
                supportedProcessorsContainProcessor = true;
            }
        }

        if (supportedProcessorsContainProcessor is false)
        {
            return new AssemblyResult.Fail();
        }

        return new AssemblyResult.Success();
    }
}