public class Q1991_FindMiddleIndexInArray
{
    public int FindMiddleIndex(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {2,3,-1,8,4}, 3],
        [new int[] {1,-1,4}, 2],
        [new int[] {2,5}, -1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FindMiddleIndex(input);
        Assert.Equal(expected, actual);
    }
}