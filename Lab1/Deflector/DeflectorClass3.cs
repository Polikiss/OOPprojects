using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public class DeflectorClass3 : IDeflector
{
    private readonly double _damageAbsorptionGradation = 0.5;
    public DeflectorClass3()
    {
        TotalStrength = 21;
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