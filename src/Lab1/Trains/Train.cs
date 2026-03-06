using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public class Train
{
    private readonly Mass _mass;

    private readonly Force _maxAllowedForce;

    private readonly TimeSpan _timeAccuracy;

    public Speed Speed { get; private set; }

    private Acceleration _acceleration;

    public Train(Mass mass, Force maxAllowedForce, TimeSpan timeAccuracy)
    {
        if (timeAccuracy <= TimeSpan.Zero)
            throw new ArgumentOutOfRangeException(nameof(timeAccuracy), "Time accuracy must be greater than zero");

        Speed = Speed.Zero;
        _acceleration = Acceleration.Zero;
        _mass = mass;
        _maxAllowedForce = maxAllowedForce;
        _timeAccuracy = timeAccuracy;
    }

    public ApplyForceResult TryApplyForce(Force force)
    {
        if (force.Exceeds(_maxAllowedForce))
            return new ApplyForceResult.Failure(new ExceedingMaxForceTrainError());

        _acceleration = Acceleration.Create(force, _mass);
        return new ApplyForceResult.Success();
    }

    public TrainResult TryCalculateDistance(Distance distance)
    {
        if (Speed == Speed.Zero && _acceleration == Acceleration.Zero)
            return new TrainResult.Failure(new NoSpeedAndAccelerationError());

        TimeSpan resultTime = TimeSpan.Zero;
        Distance curDistance = Distance.Zero;
        while (curDistance < distance)
        {
            Speed += Speed.CreateFromAccelerationAndTime(_acceleration, _timeAccuracy);
            if (Speed < Speed.Zero)
                return new TrainResult.Failure(new NegativeSpeedError());

            curDistance += Distance.Create(Speed, _timeAccuracy);
            resultTime += _timeAccuracy;
        }

        return new TrainResult.Success(resultTime);
    }
}