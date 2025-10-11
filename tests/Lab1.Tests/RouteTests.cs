using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class RouteTests
{
    private readonly Train _defaultTrain = new Train(new Mass(100), new Force(1000), TimeSpan.FromMilliseconds(100));

    [Fact]
    public void TrySimulate_Scenario1_ReturnSuccess()
    {
        IRouteSegment[] segments =
        [
            new ForceRail(new Distance(125), new Force(1000)),
            new Rail(new Distance(100))
        ];

        RunSimulatorTest(segments, new Speed(50), new RouteResult.Success(TimeSpan.FromSeconds(7)));
    }

    [Fact]
    public void TrySimulate_Scenario2_ReturnExceedingMaxRouteSpeedError()
    {
        IRouteSegment[] segments =
        [
            new ForceRail(new Distance(125), new Force(1000)),
            new Rail(new Distance(100))
        ];

        RunSimulatorTest(segments, new Speed(49), new RouteResult.Failure(new ExceedingMaxEndRouteSpeedError()));
    }

    [Fact]
    public void TrySimulate_Scenario3_ReturnSuccess()
    {
        IRouteSegment[] segments =
        [
            new ForceRail(new Distance(125), new Force(1000)),
            new Rail(new Distance(100)),
            new Station(new Speed(50)),
            new Rail(new Distance(100))
        ];

        RunSimulatorTest(segments, new Speed(50), new RouteResult.Success(TimeSpan.FromSeconds(9)));
    }

    [Fact]
    public void TrySimulate_Scenario4_ReturnExceedingMaxSpeedStationError()
    {
        IRouteSegment[] segments =
        [
            new ForceRail(new Distance(125), new Force(1000)),
            new Station(new Speed(49)),
            new Rail(new Distance(100))
        ];

        RunSimulatorTest(segments, new Speed(50), new RouteResult.Failure(new ExceedingMaxSpeedStationError()));
    }

    [Fact]
    public void TrySimulate_Scenario5_ReturnExceedingMaxEndRouteSpeedError()
    {
        IRouteSegment[] segments =
        [
            new ForceRail(new Distance(125), new Force(1000)),
            new Station(new Speed(50)),
            new Rail(new Distance(100))
        ];

        RunSimulatorTest(segments, new Speed(49), new RouteResult.Failure(new ExceedingMaxEndRouteSpeedError()));
    }

    [Fact]
    public void TrySimulate_Scenario6_ReturnSuccess()
    {
        IRouteSegment[] segments =
        [
            new ForceRail(new Distance(125), new Force(1000)),
            new Rail(new Distance(100)),
            new ForceRail(new Distance(92.5), new Force(-1000)),
            new Station(new Speed(25)),
            new Rail(new Distance(100)),
            new ForceRail(new Distance(95), new Force(1000)),
            new Rail(new Distance(100)),
            new ForceRail(new Distance(92.5), new Force(-1000))
        ];

        RunSimulatorTest(segments, new Speed(25), new RouteResult.Success(TimeSpan.FromSeconds(20.5)));
    }

    [Fact]
    public void TrySimulate_Scenario7_ReturnNoSpeedAndAccelerationError()
    {
        IRouteSegment[] segments =
        [
            new Rail(new Distance(100))
        ];

        RunSimulatorTest(segments, new Speed(100), new RouteResult.Failure(new NoSpeedAndAccelerationError()));
    }

    [Fact]
    public void TrySimulate_Scenario8_ReturnNegativeSpeedError()
    {
        IRouteSegment[] segments =
        [
            new ForceRail(new Distance(100), new Force(100)),
            new ForceRail(new Distance(100), new Force(-200))
        ];

        RunSimulatorTest(segments, new Speed(100), new RouteResult.Failure(new NegativeSpeedError()));
    }

    [Fact]
    public void TrySimulate_Scenario9_ReturnExceedingMaxForceTrainError()
    {
        IRouteSegment[] segments =
        [
            new ForceRail(new Distance(100), new Force(-1001))
        ];

        RunSimulatorTest(segments, new Speed(100), new RouteResult.Failure(new ExceedingMaxForceTrainError()));
    }

    private void RunSimulatorTest(
        IRouteSegment[] segments,
        Speed endMaxSpeed,
        RouteResult expectedRouteResult)
    {
        var simulator = new Route(segments, endMaxSpeed);

        RouteResult actualRouteResult = simulator.TryTraverse(_defaultTrain);
        if (expectedRouteResult is RouteResult.Success)
        {
            RouteResult.Success expectedSuccess = Assert.IsType<RouteResult.Success>(expectedRouteResult);
            RouteResult.Success actualSuccess = Assert.IsType<RouteResult.Success>(actualRouteResult);
            Assert.Equal(expectedSuccess.Value, actualSuccess.Value);
        }
        else
        {
            RouteResult.Failure expectedFailure = Assert.IsType<RouteResult.Failure>(expectedRouteResult);
            RouteResult.Failure actualFailure = Assert.IsType<RouteResult.Failure>(actualRouteResult);
            Assert.IsType(expectedFailure.Error.GetType(), actualFailure.Error);
        }
    }
}