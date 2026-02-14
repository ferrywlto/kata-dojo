public class Q3274_CheckIfTwoChessboardSquaresHaveTheSameColor
{
    // TC: O(1), time used is constant
    // SC: O(1), space used is constant
    public bool CheckTwoChessboards(string coordinate1, string coordinate2)
    {
        return color(coordinate1) == color(coordinate2);
    }
    public int color(string input)
    {
        var x = input[0] - 'a';
        var y = input[1] - '0';
        return (x % 2 == y % 2) ? 0 : 1;
    }
    public static TheoryData<string, string, bool> TestData => new()
    {
        {"a1", "c3", true},
        {"a1", "h3", false},
        {"d4", "e5", true},
        {"b7", "c6", true},
        {"a8", "g1", false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input1, string input2, bool expected)
    {
        var actual = CheckTwoChessboards(input1, input2);
        Assert.Equal(expected, actual);
    }
}
