public class Q2016_MaxDiffBetweenIncreasingElements
{
    public int MaximumDifference(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {7,1,5,4}, 4],
        [new int[] {9,4,3,2}, -1],
        [new int[] {1,5,2,10}, 9],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaximumDifference(input);
        Assert.Equal(expected, actual);
    }
}