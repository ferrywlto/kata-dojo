public class Q3099_HarshadNumber
{
    // TC: O(log n), n sink a factor of 10 each iteration
    // SC: O(1), space used does not scale with input
    public int SumOfTheDigitsOfHarshadNumber(int x)
    {
        var n = x;
        var sum = 0;
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }
        return x % sum == 0 ? sum : -1;
    }

    public static TheoryData<int, int> TestData => new()
    {
        {18, 9},
        {23, -1},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = SumOfTheDigitsOfHarshadNumber(input);
        Assert.Equal(expected, actual);
    }
}
