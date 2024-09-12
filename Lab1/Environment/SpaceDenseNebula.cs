using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class SpaceDenseNebula : IEnvironment
{
    public SpaceDenseNebula(int distance)
    {
        Distance = distance;
        Obstacle = null;
        Time = 0;
    }

    public SpaceDenseNebula(int distance, IAntimatterObstacle obstacle)
    {
        Distance = distance;
        Obstacle = obstacle;
        Time = 0;
    }

    public IObstacle? Obstacle { get; }
    public int Distance { get; }
    public int Time { get; private set; }
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

        if (ship.JumpEngine is null)
        {
            result = new Result.RouteResult.LoseShip();
            return result;
        }

        result = ship.JumpEngine.OvercomeEnvironment(Distance);

        return result;
    }
}