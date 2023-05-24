namespace WorkshopTime;
using System;

public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
{
    private readonly long _totalSeconds;

    public TimePeriod(long totalSeconds)
    {
        if (totalSeconds < 0)
            throw new ArgumentException("Invalid time period.");

        _totalSeconds = totalSeconds;
    }

    public TimePeriod(int hours, int minutes, int seconds)
        : this(hours * 3600L + minutes * 60L + seconds)
    {
    }

    public TimePeriod(int hours, int minutes)
        : this(hours, minutes, 0)
    {
    }

    public TimePeriod(int seconds)
        : this(0, 0, seconds)
    {
    }

    public TimePeriod(Time startTime, Time endTime)
    {
        if (endTime < startTime)
            throw new ArgumentException("Invalid time range.");

        var totalSeconds = (endTime.Hours - startTime.Hours) * 3600L + (endTime.Minutes - startTime.Minutes) * 60L +(endTime.Seconds - startTime.Seconds);

        _totalSeconds = totalSeconds;
    }

    public TimePeriod(string timeString)
    {
        var parts = timeString.Split(':');

        if (parts.Length != 3 ||
            !int.TryParse(parts[0], out var hours) ||
            !int.TryParse(parts[1], out var minutes) ||
            !int.TryParse(parts[2], out var seconds) ||
            hours < 0 || minutes < 0 || seconds < 0)
        {
            throw new ArgumentException("Invalid time period format.");
        }

        _totalSeconds = hours * 3600L + minutes * 60L + seconds;
    }

    public long TotalSeconds => _totalSeconds;

    public int Hours => (int)(_totalSeconds / 3600);

    public int Minutes => (int)((_totalSeconds / 60) % 60);

    public int Seconds => (int)(_totalSeconds % 60);

    public override string ToString()
    {
        return $"{Hours}:{Minutes:D2}:{Seconds:D2}";
    }

    public override bool Equals(object obj)
    {
        if (obj is TimePeriod otherPeriod)
        {
            return Equals(otherPeriod);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return _totalSeconds.GetHashCode();
    }

    public bool Equals(TimePeriod other)
    {
        return _totalSeconds == other._totalSeconds;
    }

    public int CompareTo(TimePeriod other)
    {
        return _totalSeconds.CompareTo(other._totalSeconds);
    }

    public static bool operator ==(TimePeriod period1, TimePeriod period2)
    {
        return period1.Equals(period2);
    }

    public static bool operator !=(TimePeriod period1, TimePeriod period2)
    {
        return !period1.Equals(period2);
    }

    public static bool operator <(TimePeriod period1, TimePeriod period2)
    {
        return period1.CompareTo(period2) < 0;
    }

    public static bool operator <=(TimePeriod period1, TimePeriod period2)
    {
        return period1.CompareTo(period2) <= 0;
    }

    public static bool operator >(TimePeriod period1, TimePeriod period2)
    {
        return period1.CompareTo(period2) > 0;
    }

    public static bool operator >=(TimePeriod period1, TimePeriod period2)
    {
        return period1.CompareTo(period2) >= 0;
    }

    public static TimePeriod operator +(TimePeriod period1, TimePeriod period2)
    {
        return new TimePeriod(period1._totalSeconds + period2._totalSeconds);
    }

    public static TimePeriod operator -(TimePeriod period1, TimePeriod period2)
    {
        return new TimePeriod(period1._totalSeconds - period2._totalSeconds);
    }

    public object? Plus(TimePeriod period2)
    {
        throw new NotImplementedException();
    }

    public object? Minus(TimePeriod period2)
    {
        throw new NotImplementedException();
    }
}
