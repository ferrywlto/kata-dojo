public class Q1769_MinNumOpsToMoveAllBallsToEachBox
{
    public int[] MinOperations(string boxes)
    {
        return [];
    }
    public static TheoryData<string, int[]> TestData => new()
    {
        {"110", [1,1,3]},
        {"001011", [11,8,5,4,3,4]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int[] expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }

}