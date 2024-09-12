using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine;

public class PulseEngineClassC : IPulseEngine
{
    private int _curentSpeed;
    public PulseEngineClassC()
    {
        SpentActivePlasma = 0;
        SpentTime = 0;
        _curentSpeed = 0;
    }

    public int SpentActivePlasma { get; private set; }
    public int SpentTime { get; private set; }

    public Result.RouteResult OvercomeEnvironment(int distance, int environmentalResistance)
    {
        distance -= StartEngine();
        CalculateCurentSpeed(environmentalResistance);
        SpentTime += CalculateTime(distance);
        SpentActivePlasma += CalculateSpentFuel(distance, environmentalResistance);
        var activePlasma = new ActivePlasma(SpentActivePlasma);
        return new Result.RouteResult.RouteSuccess(new[] { activePlasma, }, SpentTime);
    }

    private static int CalculateSpentFuel(int distance, int environmentalResistance)
    {
        int fuelСonsumption = 8;
        int fuel = distance / fuelСonsumption * environmentalResistance;
        return fuel;
    }

    private int StartEngine()
    {
        SpentActivePlasma += 5;
        _curentSpeed = 2;
        int startDistance = 3;
        return startDistance;
    }

    private int CalculateTime(int distance)
    {
        int time = distance / _curentSpeed;
        return time;
    }

    private void CalculateCurentSpeed(int environmentalResistance)
    {
        _curentSpeed = _curentSpeed / environmentalResistance;
    }
}