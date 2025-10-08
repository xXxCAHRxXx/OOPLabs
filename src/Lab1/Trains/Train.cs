using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public class Train
{
    private readonly Mass _mass;

    private readonly Force _maxAllowedForce;

    private readonly TimeSpan _deltaT;

    public Speed Speed { get; private set; }

    private Acceleration _acceleration;

    public Train(Mass mass, Force maxAllowedForce, TimeSpan deltaT)
    {
        if (deltaT <= TimeSpan.Zero)
            throw new ArgumentOutOfRangeException(nameof(deltaT), "Delta time must be greater than zero");

        Speed = Speed.Zero;
        _acceleration = Acceleration.Zero;
        _mass = mass;
        _maxAllowedForce = maxAllowedForce;
        _deltaT = deltaT;
    }

    public Result<TimeSpan> TryApplyForce(Force force)
    {
        if (force.Exceeds(_maxAllowedForce))
            return Result<TimeSpan>.Fail(new ExceedingMaxForceTrainError());

        _acceleration = Acceleration.CreateFromForceAndMass(force, _mass);
        return Result<TimeSpan>.Success(TimeSpan.Zero);
    }

    public void ResetAcceleration()
    {
        _acceleration = Acceleration.Zero;
    }

    public Result<TimeSpan> TryCalculateDistance(Distance distance)
    {
        if (Speed == Speed.Zero && _acceleration == Acceleration.Zero)
            return Result<TimeSpan>.Fail(new NoSpeedAndAccelerationError());

        TimeSpan resultTime = TimeSpan.Zero;
        Distance curDistance = Distance.Zero;
        while (curDistance < distance)
        {
            Speed += Speed.CreateFromAccelerationAndTime(_acceleration, _deltaT);
            if (Speed < Speed.Zero)
                return Result<TimeSpan>.Fail(new NegativeSpeedError());

            curDistance += Distance.CreateFromSpeedAndTime(Speed, _deltaT);
            resultTime += _deltaT;
        }

        return Result<TimeSpan>.Success(resultTime);
    }
}