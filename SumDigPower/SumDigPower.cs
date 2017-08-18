using System;
using System.Collections.Generic;
using System.Linq;


public class SumDigPower
{

    public static long[] SumDigPow(long a, long b)
    {
        if (a > b)
            throw new ArgumentException();

        var length = b - a + 1;

        var numbers = Enumerable
            .Range(a, length)
            .Where(x => IsSumDigPower(x))
            .ToArray();

        return numbers;
    }

    public static bool IsSumDigPower(long a)
    {
        var digits = a
            .ToDigits()
            .ToList();

        var sum = (long) 0;

        for (int i = 0; i < digits.Count(); i++)
            sum += (long)Math.Pow(digits[i], i + 1);

        return a == sum;
    }
}

public static class Extensions
{
    public static IEnumerable<long> ToDigits(this long a)
    {
        return a.ToString()
            .Select(x => Int64.Parse(x.ToString()));
    }
}

/// <summary>
/// Copied from https://github.com/Microsoft/referencesource/blob/master/System.Core/System/Linq/Enumerable.cs
/// and modified for long
/// </summary>
public static class Enumerable
{
    public static IEnumerable<long> Range(long start, long count)
    {
        long max = ((long)start) + count - 1;
        if (count < 0 || max > Int64.MaxValue)
            throw new ArgumentOutOfRangeException("count");

        return RangeIterator(start, count);
    }

    static IEnumerable<long> RangeIterator(long start, long count)
    {
        for (int i = 0; i < count; i++)
            yield return start + i;
    }
}

