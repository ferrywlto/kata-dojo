public class Q3908_ValidDigitNumber
{
    // TC: O(log n)
    // SC: O(1)
    public bool ValidDigit(int n, int x)
    {
        var seen = false;
        var digit = -1;
        while (n > 0)
        {
            digit = n % 10;
            if (digit == x) seen = true;
            n /= 10;
        }

        return digit != x && seen;
    }

    public static TheoryData<int, int, bool> TestData() => new()
    {
        { 101, 0, true },
        { 232, 2, false },
        { 5, 1, false },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int x, bool expected)
    {
        var actual = ValidDigit(input, x);
        Assert.Equal(expected, actual);
    }
}

