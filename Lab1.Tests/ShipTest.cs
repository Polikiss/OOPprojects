using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.RouteMembers;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShipTest
{
    [Theory]
    [ClassData(typeof(ShipTestData1))]
    public void ShipShouldNotCompleteSpaceDenseNebulaMediumLength(IShip ship)
    {
        int distance = 100;
        IEnvironment spaceDenseNebula = new SpaceDenseNebula(distance);
        IList<IEnvironment> environments = new List<IEnvironment>
        {
            spaceDenseNebula,
        };
        var route = new Route(environments);

        Result result = route.GoRoute(ship);

        Assert.False(result is Result.RouteResult.RouteSuccess);
    }

    [Theory]
    [ClassData(typeof(ShipTestData2))]
    public void ShipMeetCosmoWhaleInNitriteSpace(IShip ship, Result expectedResult)
    {
        int distance = 20;
        int obstacleCount = 1;
        var obstacle = new CosmoWhale(obstacleCount);
        IEnvironment nitriteNebula = new NitriteNebula(distance, obstacle);
        IList<IEnvironment> environments = new List<IEnvironment>
        {
            nitriteNebula,
        };
        var route = new Route(environments);

        Result result = route.GoRoute(ship);

        Assert.Equal(expectedResult.GetType(), result.GetType());
    }

    [Theory]
    [ClassData(typeof(ShipTestData3))]
    public void ShipMeetAntimatterOutbreak(IShip ship, Result expectedResult)
    {
        int distance = 20;
        int obstacleCount = 1;
        var obstacle = new AntimatterOutbreak(obstacleCount);
        IEnvironment spaceDenseNebula = new SpaceDenseNebula(distance, obstacle);
        IList<IEnvironment> environments = new List<IEnvironment>
        {
            spaceDenseNebula,
        };
        var route = new Route(environments);

        Result result = route.GoRoute(ship);

        Assert.Equal(expectedResult.GetType(), result.GetType());
    }

    [Theory]
    [ClassData(typeof(ShipTestData4))]
    public void ComplicatedRoute(IShip ship, Result expectedResult)
    {
        int distance1 = 60;
        int smallAsteroidCount = 3;
        var smallAsteroid = new SmallAsteroid(smallAsteroidCount);
        IEnvironment normalSpace = new NormalSpace(distance1, smallAsteroid);
        int distance = 20;
        int obstacleCount = 1;
        var obstacle = new AntimatterOutbreak(obstacleCount);
        IEnvironment spaceDenseNebula = new SpaceDenseNebula(distance, obstacle);
        IList<IEnvironment> environments = new List<IEnvironment>
        {
            normalSpace, spaceDenseNebula,
        };
        var route = new Route(environments);

        Result result = route.GoRoute(ship);

        Assert.Equal(expectedResult.GetType(), result.GetType());
    }

    [Fact]
    public void CompareVaclasAndPleasureShuttleInNormalSpace()
    {
        int distance = 50;
        IEnvironment normalSpace = new NormalSpace(distance);
        IList<IEnvironment> environments = new List<IEnvironment>
        {
            normalSpace,
        };
        IShip pleasureShuttle = new PleasureShuttle();
        IShip vaclas = new Vaclas(false);

        var compareShip = new CompareShipByTime(pleasureShuttle, vaclas, environments);
        IShip? shipResult = compareShip.CompareShipsByTime();

        Assert.Equal(pleasureShuttle, shipResult);
    }

    [Fact]
    public void CompareAugurAndStellaInSpaceDenseNebula()
    {
        int distance = 90;
        IEnvironment spaceDenseNebula = new SpaceDenseNebula(distance);
        IList<IEnvironment> environments = new List<IEnvironment>
        {
            spaceDenseNebula,
        };
        IShip stella = new Stella(false);
        IShip augur = new Augur(false);

        var compareShip = new CompareShipByCredit(augur, stella, environments);
        IShip? shipResult = compareShip.CompareShipsByCredit();

        Assert.Equal(stella, shipResult);
    }

    [Fact]
    public void ComparePleasureShuttleAndVaclasInNitriteNebula()
    {
        int distance = 30;
        IEnvironment nitriteNebula = new NitriteNebula(distance);
        IList<IEnvironment> environments = new List<IEnvironment>
        {
            nitriteNebula,
        };
        IShip pleasureShuttle = new PleasureShuttle();
        IShip vaclas = new Vaclas(false);

        var compareShip = new CompareShipByTime(pleasureShuttle, vaclas, environments);
        IShip? shipResult = compareShip.CompareShipsByTime();

        Assert.Equal(vaclas, shipResult);
    }

    private class ShipTestData2 : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Vaclas(false), new Result.DamageResult.ShipDestroyed() };
            yield return new object[] { new Augur(false), new Result.RouteResult.RouteSuccess(new List<IFuel>(), 0) };
            yield return new object[] { new Meredian(false), new Result.RouteResult.RouteSuccess(new List<IFuel>(), 0) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    private class ShipTestData1 : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Augur(false) };
            yield return new object[] { new PleasureShuttle() };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    private class ShipTestData3 : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Vaclas(false), new Result.DamageResult.CrewDeath() };
            yield return new object[] { new Vaclas(true), new Result.RouteResult.RouteSuccess(new List<IFuel>(), 0) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    private class ShipTestData4 : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Vaclas(false), new Result.DamageResult.CrewDeath() };
            yield return new object[] { new PleasureShuttle(), new Result.DamageResult.ShipDestroyed() };
            yield return new object[] { new Augur(true), new Result.RouteResult.RouteSuccess(new List<IFuel>(), 0) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}