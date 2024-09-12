using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

public class AntimatterOutbreak : IAntimatterObstacle
{
    public AntimatterOutbreak(int obstacleCount)
    {
        ObstacleCount = obstacleCount;
    }

    public int ObstacleCount { get; }

    public Result.DamageResult СauseDamage(IShip ship)
    {
        if (ship.ShipDefense.Deflector is not IPhotonDeflector photonDeflector)
        {
            return new Result.DamageResult.CrewDeath();
        }

        Result.DamageResult result = new Result.DamageResult.DefenceSuccess();

        for (int index = 0; index < ObstacleCount && result is Result.DamageResult.DefenceSuccess; index++)
        {
            result = photonDeflector.TakeAntimatterDamage();
        }

        if (result is Result.DamageResult.DeflectorDestroyed)
        {
            return new Result.DamageResult.CrewDeath();
        }

        return new Result.DamageResult.DefenceSuccess();
    }
}