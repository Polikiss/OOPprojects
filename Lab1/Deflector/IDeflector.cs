using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public interface IDeflector
{
    public Result.DamageResult TakeDamage(int obstacleMass);
}