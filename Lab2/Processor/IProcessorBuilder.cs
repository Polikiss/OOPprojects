namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public interface IProcessorBuilder
{
    public IProcessorBuilder WithSocket(string manufacturer, string name);
    public IProcessorBuilder WithSocket(Socket.Socket? socket);
    public IProcessorBuilder WithCoreFrequency(double coreFrequency);
    public IProcessorBuilder WithAmountCores(byte amountCores);
    public IProcessorBuilder WithBuiltInVideoCore();
    public IProcessorBuilder WithTdp(byte tdp);
    public IProcessorBuilder WithPowerConsumption(byte powerConsumption);
    public IProcessor BuildProcessor();
}