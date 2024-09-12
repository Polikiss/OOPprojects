using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel;

public interface IFuelExchange
{
    public decimal ConverteFuelToCredit(Result.RouteResult.RouteSuccess success);
}