using Itmo.ObjectOrientedProgramming.Lab1.BodyStrengthClass;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.ShipDefense;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship;

public class Stella : IShip
{
    public Stella(bool havePhotonDeflector)
    {
        IDeflector deflector = new DeflectorClass1();
        if (havePhotonDeflector is true)
        {
            deflector = new PhotonDeflector(deflector);
        }

        IBodyStrengthClass body = new BodyStrength1Class();
        ShipDefense = new ShipDefense.ShipDefense(body, deflector);
        PulseEngine = new PulseEngineClassC();
        JumpEngine = new OmegaJumpEngine();
        AntiNitriteRadiator = null;
    }

    public IPulseEngine PulseEngine { get; }
    public IJumpEngine? JumpEngine { get; }
    public IShipDefense ShipDefense { get; }
    public AntiNitriteRadiator? AntiNitriteRadiator { get; private set; }
}