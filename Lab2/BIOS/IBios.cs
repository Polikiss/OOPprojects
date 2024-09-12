using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Component;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.BIOS;

public interface IBios : IComputerComponent
{
    public string Type { get; }
    public double Version { get; }
    public IList<IProcessor> SupportedProcessorList { get; }
}