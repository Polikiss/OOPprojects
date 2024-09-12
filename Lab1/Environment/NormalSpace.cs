using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class NormalSpace : IEnvironment
{
    private readonly int _environmentalResistance = 1;
    public NormalSpace(int distance)
    {
        Distance = distance;
        Obstacle = null;
        Time = 0;
    }

    public NormalSpace(int distance, INormalSpaceObstacle obstacle)
    {
        Distance = distance;
        Obstacle = obstacle;
        Time = 0;
    }

    public IObstacle? Obstacle { get; }
    public int Distance { get; }
    public int Time { get; }
    public Result OvercomeEnvironment(IShip ship)
    {
        Result result = new Result.DamageResult.DefenceSuccess();
        if (Obstacle is not null)
        {
            result = Obstacle.СauseDamage(ship);
        }

        if (result is not Result.DamageResult.DefenceSuccess)
        {
            return result;
        }

        result = ship.PulseEngine.OvercomeEnvironment(Distance, _environmentalResistance);

        return result;
    }
}