namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel;

public class ActivePlasma : IFuel
{
    public ActivePlasma(int fuelAmount)
    {
        FuelAmount = fuelAmount;
    }

    public int FuelAmount { get; }
}