using Itmo.ObjectOrientedProgramming.Lab1.BodyStrengthClass;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipDefense;

public class ShipDefense : IShipDefense
{
    public ShipDefense(IBodyStrengthClass body, IDeflector? deflector)
    {
        Deflector = deflector;
        Body = body;
    }

    public IDeflector? Deflector { get; private set; }
    public IBodyStrengthClass Body { get; }
    public void LoseDeflector()
    {
        Deflector = null;
    }

    public Result.RouteResult.DamageResult TakeDamage(int obstacleMass)
    {
        Result.RouteResult.DamageResult deflectorResult = CauseDeflectorDamage(obstacleMass);
        if (deflectorResult is Result.RouteResult.DamageResult.DefenceSuccess)
        {
            return new Result.RouteResult.DamageResult.DefenceSuccess();
        }

        Result.RouteResult.DamageResult routeResult = CauseBodyDamage(obstacleMass);

        return routeResult;
    }

    private Result.RouteResult.DamageResult CauseBodyDamage(int obstacleMass)
    {
        Result.RouteResult.DamageResult routeResult = Body.TakeDamage(obstacleMass);
        return routeResult;
    }

    private Result.RouteResult.DamageResult CauseDeflectorDamage(int obstacleMass)
    {
        if (Deflector is not null)
        {
            Result.RouteResult.DamageResult deflectorResult = Deflector.TakeDamage(obstacleMass);
            if (deflectorResult is Result.RouteResult.DamageResult.DeflectorDestroyed)
            {
                LoseDeflector();
            }

            return deflectorResult;
        }

        return new Result.RouteResult.DamageResult.DeflectorDestroyed();
    }
}