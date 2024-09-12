using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

public class Route : IRoute
{
    public Route(IList<IEnvironment> environments)
    {
        Environments = environments;
    }

    public IList<IEnvironment> Environments { get; }
    public Result GoRoute(IShip ship)
    {
        var globalResult = new Result.RouteResult.RouteSuccess(new List<IFuel>(), 0);
        var totalFuel = new List<IFuel>();
        foreach (IEnvironment environment in Environments)
        {
            Result result = environment.OvercomeEnvironment(ship);
            if (result is not Result.RouteResult.RouteSuccess success)
            {
                return result;
            }

            int totalTime = success.Time + globalResult.Time;
            foreach (IFuel fuel in globalResult.Fuel)
            {
                totalFuel.Add(fuel);
            }

            globalResult = new Result.RouteResult.RouteSuccess(success.Fuel, totalTime);
        }

        globalResult = new Result.RouteResult.RouteSuccess(totalFuel, globalResult.Time);

        return globalResult;
    }
}