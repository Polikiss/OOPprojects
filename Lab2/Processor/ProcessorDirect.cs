namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public class ProcessorDirect : IProcessorDirect
{
    private readonly IProcessorBuilder _builder;

    public ProcessorDirect(IProcessorBuilder builder)
    {
        this._builder = builder;
    }

    public IProcessorBuilder Direct()
    {
        _builder.WithSocket("Intel", "AM3");
        _builder.WithCoreFrequency(3.8);
        _builder.WithTdp(60);
        _builder.WithAmountCores(4);
        _builder.WithPowerConsumption(120);

        return _builder;
    }
}