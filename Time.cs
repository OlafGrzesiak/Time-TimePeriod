namespace WorkshopTime;

using System;

public struct Time : IEquatable<Time>, IComparable<Time>
{
    public readonly byte Hours { get; }
    public readonly byte Minutes { get; }
    public readonly byte Seconds { get; }

    public Time(byte hours, byte minutes, byte seconds)
    {
        if (hours >= 24 || minutes >= 60 || seconds >= 60)
            throw new ArgumentException("Invalid time values.");

        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    public Time(byte hours, byte minutes) : this(hours, minutes, 0)
    {
    }

    public Time(byte hours) : this(hours, 0, 0)
    {
    }

    public Time(string timeString)
    {
        var parts = timeString.Split(':');

        if (parts.Length != 3 ||
            !byte.TryParse(parts[0], out var hours) ||
            !byte.TryParse(parts[1], out var minutes) ||
            !byte.TryParse(parts[2], out var seconds) ||
            hours >= 24 || minutes >= 60 || seconds >= 60)
        {
            throw new ArgumentException("Invalid time format.");
        }

        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    public override string ToString()
    {
        return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Time otherTime)
        {
            return Equals(otherTime);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Hours, Minutes, Seconds);
    }

    public bool Equals(Time other)
    {
        return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
    }

    public int CompareTo(Time other)
    {
        if (Hours != other.Hours)
            return Hours.CompareTo(other.Hours);
        if (Minutes != other.Minutes)
            return Minutes.CompareTo(other.Minutes);
        return Seconds.CompareTo(other.Seconds);
    }

    public static bool operator ==(Time time1, Time time2)
    {
        return time1.Equals(time2);
    }

    public static bool operator !=(Time time1, Time time2)
    {
        return !time1.Equals(time2);
    }

    public static bool operator <(Time time1, Time time2)
    {
        return time1.CompareTo(time2) < 0;
    }

    public static bool operator <=(Time time1, Time time2)
    {
        return time1.CompareTo(time2) <= 0;
    }

    public static bool operator >(Time time1, Time time2)
    {
        return time1.CompareTo(time2) > 0;
    }

    public static bool operator >=(Time time1, Time time2)
    {
        return time1.CompareTo(time2) >= 0;
    }

    public static Time operator +(Time time, TimePeriod period)
    {
        var totalSeconds = time.Hours * 3600 + time.Minutes * 60 + time.Seconds + period.TotalSeconds;
        totalSeconds %= 86400;

        var hours = (byte)(totalSeconds / 3600);
        var minutes = (byte)((totalSeconds / 60) % 60);
        var seconds = (byte)(totalSeconds % 60);

        return new Time(hours, minutes, seconds);
    }

    public object? Minus(TimePeriod period)
    {
        throw new NotImplementedException();
    }
}
