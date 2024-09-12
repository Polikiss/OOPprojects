using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public class DeflectorClass1 : IDeflector
{
    private readonly double _damageAbsorptionGradation = 1;
    public DeflectorClass1()
    {
        TotalStrength = 2;
    }

    public double TotalStrength { get; private set; }

    public Result.DamageResult TakeDamage(int obstacleMass)
    {
        TotalStrength -= obstacleMass * _damageAbsorptionGradation;
        if (TotalStrength <= 0)
        {
            return new Result.DamageResult.DeflectorDestroyed();
        }

        return new Result.DamageResult.DefenceSuccess();
    }
}