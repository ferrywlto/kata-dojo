public class Q3222_FindTheWinningPlayerInCoinGame
{
    public string WinningPlayer(int x, int y)
    {
        return string.Empty;
    }
    public static TheoryData<int, int, string> TestData => new()
    {
        {2, 7, "Alice"},
        {4, 11, "Bob"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, string expected)
    {
        var actual = WinningPlayer(input1, input2);
        Assert.Equal(expected, actual);
    }
}