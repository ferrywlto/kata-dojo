
class Q1025_DivisorGame
{
    // TC: O(1)
    // SC: O(1)
    public bool DivisorGame(int n) 
    {
        // who start with odd always lose, not matter what.
        // while whoever start with even always win, 
        // because at their turn they can simply make the number odd and pass back to opponent. 
        // Which will eventually force opponent pass 2 back and win
        return n % 2 == 0;
    }
}
class Q1025_DivisorGameTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [2, true],
        [3, false],
        [4, true],
        [5, false],
        [6, true],
        [7, false],
        [8, true],
        [9, false],
        [10, true],
        [11, false],
        [12, true],
        [15, false],
        [int.MaxValue, false],
    ];
}
public class Q1025_DivisorGameTests
{
    [Theory]
    [ClassData(typeof(Q1025_DivisorGameTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q1025_DivisorGame();
        var actual = sut.DivisorGame(input);
        Assert.Equal(expected, actual);
    }
}