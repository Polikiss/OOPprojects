using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;

namespace Itmo.ObjectOrientedProgramming.Lab2.BIOS;

public class BiosBuilder : IBiosBuilder
{
    private string? _type;
    private double _version;
    private IList<IProcessor>? _supportedProcessorList;
    public IBiosBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public IBiosBuilder WithVersion(double version)
    {
        _version = version;
        return this;
    }

    public IBiosBuilder WithSupportedProcessorList(IList<IProcessor> supportedProcessorList)
    {
        _supportedProcessorList = supportedProcessorList;
        return this;
    }

    public IBiosBuilder AddSupportedProcessorList(IProcessor processor)
    {
        _supportedProcessorList?.Add(processor);
        return this;
    }

    public IBios BuildBios()
    {
        return new Bios(
            _type ?? throw new MissingMemberException(),
            _version,
            _supportedProcessorList ?? throw new MissingMemberException());
    }
}