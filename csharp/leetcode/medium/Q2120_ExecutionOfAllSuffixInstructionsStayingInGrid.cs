public class Q2120_ExecutionOfAllSuffixInstructionsStayingInGrid
{
    public int[] ExecuteInstructions(int n, int[] startPos, string s)
    {
        var result = new int[s.Length];
        for (var i = 0; i < s.Length; i++)
        {
            result[i] = CountExecutedCommands(n, startPos, s, i);
        }
        return result;
    }
    private int CountExecutedCommands(int n, int[] startPos, string s, int startIdx)
    {
        var row = startPos[0];
        var col = startPos[1];
        var executed = 0;
        for (var i = startIdx; i < s.Length; i++)
        {
            var cmd = s[i];
            if (cmd == 'R')
            {
                if (col < n - 1)
                {
                    col++;
                    executed++;
                }
                else return executed;
            }
            else if (cmd == 'L')
            {
                if (col > 0)
                {
                    col--;
                    executed++;
                }
                else return executed;
            }
            else if (cmd == 'U')
            {
                if (row > 0)
                {
                    row--;
                    executed++;
                }
                else return executed;
            }
            else if (cmd == 'D')
            {
                if (row < n - 1)
                {
                    row++;
                    executed++;
                }
                else return executed;
            }
        }
        return executed;
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
