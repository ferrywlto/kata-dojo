public class Q2239_FindClosestNumberToZero
{
    public int FindClosestNumber(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[]{-4,-2,1,4,8}, 1],
        [new int[]{2,-1,1}, 1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FindClosestNumber(input);
        Assert.Equal(expected, actual);
    }
}