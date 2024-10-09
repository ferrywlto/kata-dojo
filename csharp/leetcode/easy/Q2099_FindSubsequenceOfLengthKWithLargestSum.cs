public class Q2099_FindSubsequenceOfLengthKWithLargestSum
{
    public int[] MaxSubsequence(int[] nums, int k)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [new int[]{2,1,3,3}, 2, new int[]{3,3}],
        [new int[]{-1,-2,3,4}, 3, new int[]{-1,3,4}],
        [new int[]{3,4,3,3}, 2, new int[]{3,4}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int[] expected)
    {
        var actual = MaxSubsequence(input, k);
        Assert.Equal(expected, actual);
    }
}