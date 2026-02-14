public class Q3360_StoneRemovealGame
{
    // TC: O(n), n scale with size of n
    // SC: O(1), space used does not scale with input
    public bool CanAliceWin(int n)
    {
        // turn % 2 == 0 => Alice
        var turn = 0;
        var stonePickCount = 10;
        while (stonePickCount > 0)
        {
            if (n >= stonePickCount)
            {
                n -= stonePickCount;
                stonePickCount--;
                turn++;
            }
            else return turn % 2 == 1;
        }
        return turn % 2 != 0;
    }
    public static TheoryData<int, bool> TestData => new()
    {
        {12, true},
        {1, false}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, bool expected)
    {
        var actual = CanAliceWin(input);
        Assert.Equal(expected, actual);
    }
}
