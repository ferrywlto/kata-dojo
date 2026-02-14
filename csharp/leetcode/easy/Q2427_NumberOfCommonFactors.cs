public class Q2427_NumberOfCommonFactors
{
    // TC: O(n), n scale with minimum between a and b
    // SC: O(1), space used does not scale with input
    // This use brute force as the constraint is small, use Euclidean algorithm to get GCD first otherwise
    public int CommonFactors(int a, int b)
    {
        var min = Math.Min(a, b);
        var count = 1;
        for (var i = 2; i <= min; i++)
        {
            if (a % i == 0 && b % i == 0) count++;
        }
        return count;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {12, 6, 4},
        {25, 30, 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int expected)
    {
        var actual = CommonFactors(input1, input2);
        Assert.Equal(expected, actual);
    }
}
