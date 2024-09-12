using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.BIOS;

public interface IBiosBuilder
{
    public IBiosBuilder WithType(string type);
    public IBiosBuilder WithVersion(double version);
    public IBiosBuilder WithSupportedProcessorList(IList<IProcessor> supportedProcessorList);
    public IBiosBuilder AddSupportedProcessorList(IProcessor processor);
    public IBios BuildBios();
}