namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel;

public class GravitationalMatter : IFuel
{
    public GravitationalMatter(int fuelAmount)
    {
        FuelAmount = fuelAmount;
    }

    public int FuelAmount { get; }
}