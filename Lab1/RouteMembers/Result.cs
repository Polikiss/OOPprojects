using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;

public record Result()
{
    public record DamageResult() : Result
    {
        public sealed record CrewDeath : DamageResult;

        public sealed record ShipDestroyed : DamageResult;

        public sealed record DefenceSuccess : DamageResult;

        public sealed record DeflectorDestroyed : DamageResult;
    }

    public record RouteResult() : Result
    {
        public sealed record RouteSuccess(IReadOnlyCollection<IFuel> Fuel, int Time) : RouteResult;

        public sealed record LoseShip : RouteResult;
    }
}