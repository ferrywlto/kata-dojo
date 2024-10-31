public class Q2293_MinMaxGame
{
    public int MinMaxGame(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,3,5,2,4,8,2,2}, 1],
        [new int[] {3}, 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinMaxGame(input);
        Assert.Equal(expected, actual);
    }
}