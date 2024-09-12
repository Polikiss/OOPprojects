using Itmo.ObjectOrientedProgramming.Lab1.BodyStrengthClass;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.ShipDefense;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship;

public class Meredian : IShip
{
    public Meredian(bool havePhotonDeflector)
    {
        IDeflector deflector = new DeflectorClass1();
        if (havePhotonDeflector is true)
        {
            deflector = new PhotonDeflector(deflector);
        }

        IBodyStrengthClass body = new BodyStrength2Class();
        ShipDefense = new ShipDefense.ShipDefense(body, deflector);
        PulseEngine = new PulseEngineClassE();
        JumpEngine = new GammaJumpEngine();
        AntiNitriteRadiator = new AntiNitriteRadiator();
    }

    public IPulseEngine PulseEngine { get; private set; }
    public IJumpEngine? JumpEngine { get; private set; }
    public IShipDefense ShipDefense { get; }
    public AntiNitriteRadiator? AntiNitriteRadiator { get; private set; }
}