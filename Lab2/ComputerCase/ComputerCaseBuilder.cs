using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;

public class ComputerCaseBuilder : IComputerCaseBuilder
{
    private WidthAndHigh? _maxWidthAndHighVideoCard;
    private IList<FormFactor>? _availableFormFactors = new List<FormFactor>();
    private Dimension? _dimension;

    public IComputerCaseBuilder WithMaxWidthAndHighVideoCard(uint high, uint width)
    {
        _maxWidthAndHighVideoCard = new WidthAndHigh(high, width);
        return this;
    }

    public IComputerCaseBuilder WithMaxWidthAndHighVideoCard(WidthAndHigh? widthAndHigh)
    {
        _maxWidthAndHighVideoCard = widthAndHigh;
        return this;
    }

    public IComputerCaseBuilder WithAvailableFormFactors(IList<FormFactor> availableFormFactors)
    {
        _availableFormFactors = availableFormFactors;
        return this;
    }

    public IComputerCaseBuilder AddFormFactors(FormFactor formFactor)
    {
        _availableFormFactors?.Add(formFactor);
        return this;
    }

    public IComputerCaseBuilder WithDimension(uint high, uint width, uint length)
    {
        _dimension = new Dimension(high, width, length);
        return this;
    }

    public IComputerCaseBuilder WithDimension(Dimension? dimension)
    {
        _dimension = dimension;
        return this;
    }

    public ComputerCase Build()
    {
        return new ComputerCase(
            _maxWidthAndHighVideoCard ?? throw new MissingMemberException(),
            _availableFormFactors ?? throw new MissingMemberException(),
            _dimension ?? throw new MissingMemberException());
    }
}