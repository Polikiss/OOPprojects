using System;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine;

public class OmegaJumpEngine : IJumpEngine
{
    private readonly int _totalTime = 30;
    private readonly int _range = 100;
    public OmegaJumpEngine()
    {
        SpentTime = 0;
        SpentGravitationalMatter = 0;
    }

    public int SpentTime { get; private set; }
    public int SpentGravitationalMatter { get; private set; }

    public Result.RouteResult OvercomeEnvironment(int distance)
    {
        if (distance > _range)
        {
            return new Result.RouteResult.LoseShip();
        }

        decimal distanceRatio = distance / _range;
        SpentTime += (int)(_totalTime * distanceRatio);
        SpentGravitationalMatter += (int)(SpentTime * Math.Log(SpentTime));
        IFuel gravitationalMatter = new GravitationalMatter(SpentGravitationalMatter);
        return new Result.RouteResult.RouteSuccess(new[] { gravitationalMatter, }, SpentTime);
    }
}