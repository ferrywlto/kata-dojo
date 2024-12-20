public class Q2682_FindLosersOfCircularGame
{
    public int[] CircularGameLosers(int n, int k)
    {
        return [];
    }
    public static TheoryData<int, int, int[]> TestData => new()
    {
        {5, 2, [4, 5]},
        {4, 4, [2, 3, 4]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int k, int[] expected)
    {
        var actual = CircularGameLosers(input, k);
        Assert.Equal(expected, actual);
    }
}