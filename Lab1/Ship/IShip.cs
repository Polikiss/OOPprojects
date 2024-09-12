using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.ShipDefense;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship;

public interface IShip
{
    public IPulseEngine PulseEngine { get; }
    public IJumpEngine? JumpEngine { get; }
    public IShipDefense ShipDefense { get; }
    public AntiNitriteRadiator? AntiNitriteRadiator { get; }
}