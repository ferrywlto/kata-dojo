public class Q3274_CheckIfTwoChessboardSquaresHaveTheSameColor
{
    public bool CheckTwoChessboards(string coordinate1, string coordinate2)
    {
        return false;
    }
    public static TheoryData<string, string, bool> TestData => new()
    {
        {"a1", "c3", true},
        {"a1", "h3", false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input1, string input2, bool expected)
    {
        var actual = CheckTwoChessboards(input1, input2);
        Assert.Equal(expected, actual);
    }
}