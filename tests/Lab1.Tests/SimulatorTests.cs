using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Paths;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Simulators;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SimulatorTests
{
    private readonly Train _defaultTrain = new Train(new Mass(100), new Force(1000), TimeSpan.FromMilliseconds(100));

    [Fact]
    public void TrySimulate_Scenario1_ReturnSuccess()
    {
        IRouteSegment[] segments =
        [
            new ForceRoute(new Distance(125), new Force(1000)),
            new Route(new Distance(100))
        ];

        RunSimulatorTest(segments, new Speed(50), Result<TimeSpan>.Success(TimeSpan.FromSeconds(7)));
    }

    [Fact]
    public void TrySimulate_Scenario2_ReturnExceedingMaxRouteSpeedError()
    {
        IRouteSegment[] segments =
        [
            new ForceRoute(new Distance(125), new Force(1000)),
            new Route(new Distance(100))
        ];

        RunSimulatorTest(segments, new Speed(49), Result<TimeSpan>.Fail(new ExceedingMaxEndRouteSpeedError()));
    }

    [Fact]
    public void TrySimulate_Scenario3_ReturnSuccess()
    {
        IRouteSegment[] segments =
        [
            new ForceRoute(new Distance(125), new Force(1000)),
            new Route(new Distance(100)),
            new Station(new Speed(50)),
            new Route(new Distance(100))
        ];

        RunSimulatorTest(segments, new Speed(50), Result<TimeSpan>.Success(TimeSpan.FromSeconds(9)));
    }

    [Fact]
    public void TrySimulate_Scenario4_ReturnExceedingMaxSpeedStationError()
    {
        IRouteSegment[] segments =
        [
            new ForceRoute(new Distance(125), new Force(1000)),
            new Station(new Speed(49)),
            new Route(new Distance(100))
        ];

        RunSimulatorTest(segments, new Speed(50), Result<TimeSpan>.Fail(new ExceedingMaxSpeedStationError()));
    }

    [Fact]
    public void TrySimulate_Scenario5_ReturnExceedingMaxEndRouteSpeedError()
    {
        IRouteSegment[] segments =
        [
            new ForceRoute(new Distance(125), new Force(1000)),
            new Station(new Speed(50)),
            new Route(new Distance(100))
        ];

        RunSimulatorTest(segments, new Speed(49), Result<TimeSpan>.Fail(new ExceedingMaxEndRouteSpeedError()));
    }

    [Fact]
    public void TrySimulate_Scenario6_ReturnSuccess()
    {
        IRouteSegment[] segments =
        [
            new ForceRoute(new Distance(125), new Force(1000)),
            new Route(new Distance(100)),
            new ForceRoute(new Distance(92.5), new Force(-1000)),
            new Station(new Speed(25)),
            new Route(new Distance(100)),
            new ForceRoute(new Distance(95), new Force(1000)),
            new Route(new Distance(100)),
            new ForceRoute(new Distance(92.5), new Force(-1000))
        ];

        RunSimulatorTest(segments, new Speed(25), Result<TimeSpan>.Success(TimeSpan.FromSeconds(20.5)));
    }

    [Fact]
    public void TrySimulate_Scenario7_ReturnNoSpeedAndAccelerationError()
    {
        IRouteSegment[] segments =
        [
            new Route(new Distance(100))
        ];

        RunSimulatorTest(segments, new Speed(100), Result<TimeSpan>.Fail(new NoSpeedAndAccelerationError()));
    }

    [Fact]
    public void TrySimulate_Scenario8_ReturnNegativeSpeedError()
    {
        IRouteSegment[] segments =
        [
            new ForceRoute(new Distance(100), new Force(100)),
            new ForceRoute(new Distance(100), new Force(-200))
        ];

        RunSimulatorTest(segments, new Speed(100), Result<TimeSpan>.Fail(new NegativeSpeedError()));
    }

    [Fact]
    public void TrySimulate_Scenario9_ReturnExceedingMaxForceTrainError()
    {
        IRouteSegment[] segments =
        [
            new ForceRoute(new Distance(100), new Force(-1001))
        ];

        RunSimulatorTest(segments, new Speed(100), Result<TimeSpan>.Fail(new ExceedingMaxForceTrainError()));
    }

    private void RunSimulatorTest(
        IRouteSegment[] segments,
        Speed endMaxSpeed,
        Result<TimeSpan> expectedResult)
    {
        var simulator = new Simulator(segments, endMaxSpeed);

        Result<TimeSpan> actualResult = simulator.TrySimulate(_defaultTrain);
        if (expectedResult.IsSuccess)
        {
            Assert.True(actualResult.IsSuccess, "Result should be success.");
            Success<TimeSpan> expectedSuccess = Assert.IsType<Success<TimeSpan>>(expectedResult);
            Success<TimeSpan> actualSuccess = Assert.IsType<Success<TimeSpan>>(actualResult);
            Assert.Equal(expectedSuccess.Value, actualSuccess.Value);
        }
        else
        {
            Assert.True(actualResult.IsFailure, "Result should be failure.");
            Failure<TimeSpan> expectedFailure = Assert.IsType<Failure<TimeSpan>>(expectedResult);
            Failure<TimeSpan> actualFailure = Assert.IsType<Failure<TimeSpan>>(actualResult);
            Assert.IsType(expectedFailure.Error.GetType(), actualFailure.Error);
        }
    }
}