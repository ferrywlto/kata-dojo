public class Q3222_FindTheWinningPlayerInCoinGame
{
    // TC: O(x), x scale with larger between x and y
    // SC: O(x), same as time  
    public string WinningPlayer(int x, int y)
    {
        // the only combination of 115 is 75 + 40
        var turn = 0;
        while (x > 0 && y > 3)
        {
            turn++;
            x--;
            y -= 4;
        }
        return turn % 2 == 1 ? "Alice" : "Bob";
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