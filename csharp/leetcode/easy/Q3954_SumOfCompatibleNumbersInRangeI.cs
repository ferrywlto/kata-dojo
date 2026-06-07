public class Q3954_SumOfCompatibleNumbersInRangeI
{
    // TC: O(n + k)
    // SC: O(1)
    public int SumOfGoodIntegers(int n, int k)
    {
        var result = 0;
        var start = Math.Max(0, n - k);
        var end = n + k;
        for (var i = start; i <= end; i++)
        {
            if ((n & i) == 0) result += i;
        }

        return result;
    }

    public static TheoryData<int, int, int> TestData => new()
    {
        { 2, 3, 10 },
        { 5, 1, 0 },
        { 6, 2, 8 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int k, int expected)
    {
        var actual = SumOfGoodIntegers(n, k);
        Assert.Equal(expected, actual);
    }
}
