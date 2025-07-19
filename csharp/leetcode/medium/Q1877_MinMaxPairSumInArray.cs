public class Q1877_MinMaxPairSumInArray
{
    public int MinPairSum(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        { [3, 5, 2, 3], 7 },
        { [1, 2, 3, 4, 5], 6 },
        { [1, 100000], 100001 },
        { [-1, -2, -3, -4], -5 },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinPairSum(input);
        Assert.Equal(expected, actual);
    }
}