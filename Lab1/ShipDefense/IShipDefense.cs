using Itmo.ObjectOrientedProgramming.Lab1.BodyStrengthClass;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipDefense;

public interface IShipDefense
{
    public IDeflector? Deflector { get; }
    public IBodyStrengthClass Body { get; }
    public void LoseDeflector();
    public Result.DamageResult TakeDamage(int obstacleMass);
}