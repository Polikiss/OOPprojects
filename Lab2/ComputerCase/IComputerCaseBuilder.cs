using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;

public interface IComputerCaseBuilder
{
    public IComputerCaseBuilder WithMaxWidthAndHighVideoCard(uint high, uint width);
    public IComputerCaseBuilder WithMaxWidthAndHighVideoCard(WidthAndHigh? widthAndHigh);
    public IComputerCaseBuilder AddFormFactors(FormFactor formFactor);
    public IComputerCaseBuilder WithAvailableFormFactors(IList<FormFactor> availableFormFactors);

    public IComputerCaseBuilder WithDimension(uint high, uint width, uint length);
    public IComputerCaseBuilder WithDimension(Dimension? dimension);

    public ComputerCase Build();
}