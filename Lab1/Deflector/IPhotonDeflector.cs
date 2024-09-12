using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public interface IPhotonDeflector : IDeflector
{
    public Result.DamageResult TakeAntimatterDamage();
}