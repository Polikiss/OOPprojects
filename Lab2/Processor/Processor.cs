namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public class Processor : IProcessor
{
    public Processor(Socket.Socket socket, double coreFrequency, byte amountCores, BuiltInVideoCore? builtInVideoCore, byte tdp, byte powerConsumption)
    {
        Socket = socket;
        CoreFrequency = coreFrequency;
        AmountCores = amountCores;
        BuiltInVideoCore = builtInVideoCore;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public Socket.Socket Socket { get; }
    public double CoreFrequency { get; }
    public byte AmountCores { get; }
    public BuiltInVideoCore? BuiltInVideoCore { get; }
    public byte Tdp { get; }
    public byte PowerConsumption { get; }

    public static bool Equals(Processor left, Processor right)
    {
        if (left.Socket == right.Socket && left.BuiltInVideoCore == right.BuiltInVideoCore)
        {
            if (left.PowerConsumption == right.PowerConsumption && left.Tdp == right.Tdp)
            {
                if (left.AmountCores == right.AmountCores && left.CoreFrequency == right.CoreFrequency)
                {
                    return true;
                }
            }
        }

        return false;
    }
}