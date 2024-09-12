using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.BIOS;

public class BiosDirect : IBiosDirect
{
    private IBiosBuilder _builder;

    public BiosDirect(IBiosBuilder builder)
    {
        _builder = builder;
    }

    public IBiosBuilder Direct()
    {
        _builder.WithType("AMI");
        _builder.WithVersion(2.2);

        IProcessorDirect processorDirect = new ProcessorDirect(new ProcessorBuilder());
        IProcessor processor = processorDirect.Direct().BuildProcessor();
        var processors = new List<IProcessor>
        {
            processor,
        };

        _builder.WithSupportedProcessorList(processors);
        return _builder;
    }
}