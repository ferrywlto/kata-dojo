public class Q2357_MakeArrayZeroBySubstractingEqualAmounts
{
    public int MinimumOperations(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,5,0,3,5}, 3],
        [new int[] {0}, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumOperations(input);
        Assert.Equal(expected, actual);
    }
}