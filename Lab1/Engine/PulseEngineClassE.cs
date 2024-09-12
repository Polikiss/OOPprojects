using System;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine;

public class PulseEngineClassE : IPulseEngine
{
    private int _curentSpeed;
    public PulseEngineClassE()
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
        CalculateCurentSpeed(distance);
        SpentActivePlasma += CalculateSpentFuel(environmentalResistance);
        SpentTime += CalculateTime(distance);
        var activePlasma = new ActivePlasma(SpentActivePlasma);
        return new Result.RouteResult.RouteSuccess(new[] { activePlasma, }, SpentTime);
    }

    private int StartEngine()
    {
        SpentActivePlasma = 1;
        _curentSpeed = 1;
        int startDistance = 1;
        return startDistance;
    }

    private int CalculateTime(int distance)
    {
        int time = distance / _curentSpeed;
        return time;
    }

    private void CalculateCurentSpeed(int distance)
    {
        int speedGrow = 50;
        _curentSpeed += distance / speedGrow;
        _curentSpeed = (int)Math.Exp(_curentSpeed);
    }

    private int CalculateSpentFuel(int environmentalResistance)
    {
        int fuelRatio = 5;
        int fuel = _curentSpeed * fuelRatio * environmentalResistance;
        return fuel;
    }
}