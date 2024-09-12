using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.BIOS;

public class Bios : IBios
{
    public Bios(string type, double version, IList<IProcessor> supportedProcessorList)
    {
        Type = type;
        Version = version;
        SupportedProcessorList = supportedProcessorList;
    }

    public string Type { get; }
    public double Version { get; }
    public IList<IProcessor> SupportedProcessorList { get; }
}