public class Q1823_FindWinnerOfCircularGame
{
    public int FindTheWinner(int n, int k)
    {
        return 0;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {5, 2, 3},
        {6, 5, 1},
        {3, 1, 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int k, int expected)
    {
        var actual = FindTheWinner(n, k);
        Assert.Equal(expected, actual);
    }
}