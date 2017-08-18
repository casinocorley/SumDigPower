using System;
using NUnit.Framework;


[TestFixture]
public static class SumDigPowerTests
{
    [Test]
    public static void DoesntErrorWhenRangeIsValid()
    {
        Assert.DoesNotThrow(() => SumDigPower.SumDigPow(1, 2));
    }

    [Test]
    public static void DoesErrorWhenRangeIsInvalid()
    {
        Assert.Throws<ArgumentException>(() => SumDigPower.SumDigPow(2, 1));
    }
    [Test]
    public static void DoesntErrorWhenRangeIsSameNumber()
    {
        Assert.DoesNotThrow(() => SumDigPower.SumDigPow(1, 1));
    }

    [Test]
    public static void Number89IsValid()
    {
        // Arrange

        // Act
        var isValid = SumDigPower.IsSumDigPower(89);

        // Assert
        Assert.IsTrue(isValid);
    }

    [Test]
    public static void Number10IsInvalid()
    {
        // Arrange

        // Act
        var isValid = SumDigPower.IsSumDigPower(10);

        // Assert
        Assert.IsFalse(isValid);
    }

    private static string Array2String(long[] list)
    {
        return "[" + string.Join(", ", list) + "]";
    }
    private static void testing(long a, long b, long[] res)
    {
        Assert.AreEqual(Array2String(res),
                        Array2String(SumDigPower.SumDigPow(a, b)));
    }
    [Test]
    public static void test1()
    {
        Console.WriteLine("Basic Tests SumDigPow");
        testing(1, 10, new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        testing(1, 100, new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 89 });
        testing(10, 100, new long[] { 89 });
        testing(90, 100, new long[] { });
        testing(90, 150, new long[] { 135 });
        testing(50, 150, new long[] { 89, 135 });
        testing(10, 150, new long[] { 89, 135 });

    }
}

