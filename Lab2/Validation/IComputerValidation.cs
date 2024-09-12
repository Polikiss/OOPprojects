using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validation;

public interface IComputerValidation
{
    public AssemblyResult Validation(ValidationModel validationModel);
}
