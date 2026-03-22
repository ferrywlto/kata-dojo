public class Q3871_CountCommasInRangeII
{
    public long CountCommas(long n)
    {
        // Since n <= 100000, result = n - 999
        // 999_999 to 1_000 * 1
        // 999_999_999 to 1_000_000 * 2
        // 999_999_999_999 to 1_000_000_000 * 3
        // 999_999_999_999_999 to 1_000_000_000_000 * 4
        const long diffT1 = 999_000;
        const long diffT2 = 999_000_000 * 2;
        const long diffT3 = 999_000_000_000 * 3;
        const long diffT4 = 999_000_000_000_000 * 4;

        var result = 0L;

        if (n < 1000) return 0;

        if (n > 999_999)
        {
            result += diffT1;
        }
        else return n - 999;

        if (n > 999_999_999)
        {
            result += diffT2;
        }
        else return result + (n - 999_999) * 2;

        if (n > 999_999_999_999)
        {
            result += diffT3;
        }
        else return result + (n - 999_999_999) * 3;

        if (n > 999_999_999_999_999)
            // The +5 is the 5 commas for 1_000_000_000_000_000 itself
            return result + diffT4 + 5;

        return result + (n - 999_999_999_999) * 4;
    }

    public static TheoryData<long, long> TestData => new()
    {
        { 1002, 3 },
        { 998, 0 },
        { 1000, 1 },
        { 100000, 99001 },
        { 1004590, 1008182 },
        { 1000000000000000, 3998998998999005 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(long input, long expected)
    {
        var actual = CountCommas(input);
        Assert.Equal(expected, actual);
    }
}
