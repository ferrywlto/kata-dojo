public class Q1984_MinDiffBetweenHighestAndLowestKScores
{
    public int MinimumDifference(int[] nums, int k)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {90}, 1, 0],
        [new int[] {9,4,1,7}, 2, 2],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = MinimumDifference(input, k);
        Assert.Equal(expected, actual);
    }
}
