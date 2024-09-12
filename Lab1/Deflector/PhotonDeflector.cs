using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public class PhotonDeflector : IPhotonDeflector
{
    private readonly IDeflector _deflector;
    public PhotonDeflector(IDeflector deflector)
    {
        _deflector = deflector;
        TotalStrength = 3;
    }

    public int TotalStrength { get; private set; }
    public Result.DamageResult TakeDamage(int obstacleMass)
    {
        return _deflector.TakeDamage(obstacleMass);
    }

    public Result.DamageResult TakeAntimatterDamage()
    {
         TotalStrength -= 1;
         if (TotalStrength == 0)
         {
             return new Result.DamageResult.DeflectorDestroyed();
         }

         return new Result.DamageResult.DefenceSuccess();
    }
}
