using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.BodyStrengthClass;

public class BodyStrength2Class : IBodyStrengthClass
{
    private readonly double _damageAbsorptionGradation = 0.8;
    public BodyStrength2Class()
    {
        TotalStrength = 4;
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