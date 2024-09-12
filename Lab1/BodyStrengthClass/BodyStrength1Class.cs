using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.BodyStrengthClass;

public class BodyStrength1Class : IBodyStrengthClass
{
    private readonly double _damageAbsorptionGradation = 1;
    public BodyStrength1Class()
    {
       TotalStrength = 1;
    }

    public double TotalStrength { get; private set; }

    public Result.DamageResult TakeDamage(int obstacleMass)
    {
        TotalStrength -= obstacleMass * _damageAbsorptionGradation;
        if (TotalStrength <= 0)
        {
            return new Result.DamageResult.ShipDestroyed();
        }

        return new Result.DamageResult.DefenceSuccess();
    }
}