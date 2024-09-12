using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Component;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;
namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;

public interface IComputerCase : IComputerComponent
{
    public WidthAndHigh MaxWidthAndHighVideoCard { get; }
    public IList<FormFactor> AvailableFormFactors { get; }
    public Dimension Dimension { get; }
}