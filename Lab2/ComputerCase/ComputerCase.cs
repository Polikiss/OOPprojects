using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;

public class ComputerCase : IComputerCase
{
    public ComputerCase(WidthAndHigh maxWidthAndHighVideoCard, IList<FormFactor> availableFormFactors, Dimension dimension)
    {
        MaxWidthAndHighVideoCard = maxWidthAndHighVideoCard;
        AvailableFormFactors = availableFormFactors;
        Dimension = dimension;
    }

    public WidthAndHigh MaxWidthAndHighVideoCard { get; }
    public IList<FormFactor> AvailableFormFactors { get; }
    public Dimension Dimension { get; }
}