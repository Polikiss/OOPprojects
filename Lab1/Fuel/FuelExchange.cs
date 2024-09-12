using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel;

public class FuelExchange : IFuelExchange
{
    public FuelExchange()
    {
        ActivePlasmaPrice = 2;
        GravitationalMatterPrice = 3;
    }

    public FuelExchange(decimal fuelPrice, decimal gravitationalMatterPrice)
    {
        ActivePlasmaPrice = fuelPrice;
        GravitationalMatterPrice = gravitationalMatterPrice;
    }

    public decimal ActivePlasmaPrice { get; }
    public decimal GravitationalMatterPrice { get; }
    public decimal ConverteFuelToCredit(Result.RouteResult.RouteSuccess success)
    {
        decimal totalCreditAmount = 0;
        foreach (IFuel fuel in success.Fuel)
        {
            if (fuel is ActivePlasma)
            {
                totalCreditAmount += fuel.FuelAmount * ActivePlasmaPrice;
            }
            else if (fuel is GravitationalMatter)
            {
                totalCreditAmount += fuel.FuelAmount * GravitationalMatterPrice;
            }
        }

        return totalCreditAmount;
    }
}