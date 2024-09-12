namespace Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;

public class ProcessorCoolingSystemDirect : IProcessorCoolingSystemDirect
{
    private readonly IProcessorCoolingSystemBuilder _builder;

    public ProcessorCoolingSystemDirect(IProcessorCoolingSystemBuilder builder)
    {
        _builder = builder;
    }

    public IProcessorCoolingSystemBuilder Direct()
    {
        _builder.WithTdp(65);
        _builder.WithDimension(54, 100, 100);
        _builder.AddSupportedSocket(new Socket.Socket("Intel", "AM3"));
        _builder.AddSupportedSocket(new Socket.Socket("Intel", "AM4"));

        return _builder;
    }
}