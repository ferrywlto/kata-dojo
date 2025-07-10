public class Q2120_ExecutionOfAllSuffixInstructionsStayingInGrid
{
    public int[] ExecuteInstructions(int n, int[] startPos, string s)
    {
        return [];
    }
    public static TheoryData<int, int[], string, int[]> TestData => new()
    {
        {3, [0,1], "RRDDLU", [1,5,4,3,1,0]},
        {2, [1,1], "LURD", [4,1,0,0]},
        {1, [0,0], "LRUD", [0,0,0,0]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[] startPos, string cmd, int[] expected)
    {
        var actual = ExecuteInstructions(n, startPos, cmd);
        Assert.Equal(expected, actual);
    }
}