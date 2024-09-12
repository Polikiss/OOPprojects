using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validation;

public class ProcessorValidation : IComputerValidation
{
    public AssemblyResult Validation(ValidationModel validationModel)
    {
        if (validationModel.Processor.BuiltInVideoCore is null && validationModel.VideoCard is null)
        {
            return new AssemblyResult.Fail();
        }

        if (validationModel.Processor.Socket != null && validationModel.ProcessorCoolingSystem?.SupportedSocketList is not null)
        {
            bool supportedSocketsContainSocket = false;
            foreach (Socket.Socket supportedSocket in validationModel.ProcessorCoolingSystem.SupportedSocketList)
            {
                if (validationModel.Processor.Socket == supportedSocket)
                {
                    supportedSocketsContainSocket = true;
                }
            }

            if (supportedSocketsContainSocket is false)
            {
                return new AssemblyResult.Fail();
            }
        }

        if (validationModel.ProcessorCoolingSystem != null && validationModel.Processor.Tdp > validationModel.ProcessorCoolingSystem.Tdp)
        {
            return new AssemblyResult.SuccessWithWarning("Weak Cooling System");
        }

        return new AssemblyResult.Success();
    }
}