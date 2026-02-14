public class Q2485_FindPivotInteger
{
    // TC: O(n), n scale with size of n
    // SC: O(1), space used does not scale with input
    public int PivotInteger(int n)
    {
        var sum = (1 + n) * n / 2;
        var lhs = 0;
        var rhs = sum;
        for (var i = 1; i <= n; i++)
        {
            lhs += i;
            rhs = sum - lhs + i;
            if (lhs == rhs) return i;
        }
        return -1;
    }
    public static List<object[]> TestData =>
    [
        [8,6],
        [1,1],
        [4,-1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = PivotInteger(input);
        Assert.Equal(expected, actual);
    }
}
