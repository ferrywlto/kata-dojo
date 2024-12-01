public class Q2574_LeftAndRightSumDifferences
{
    public int[] LeftRightDifference(int[] nums)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [new int[] {10,4,8,3}, new int[] {15,1,11,22}],
        [new int[] {1}, new int[] {0}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = LeftRightDifference(input);
        Assert.Equal(expected, actual);
    }
}