public class Q3248_SnakeInMatrix
{
    // TC: O(n), n scale with length of commands
    // SC: O(1), space used does not scale with input
    public int FinalPositionOfSnake(int n, IList<string> commands)
    {
        var result = 0;
        for (var i = 0; i < commands.Count; i++)
        {
            switch (commands[i])
            {
                case "UP": result -= n; break;
                case "DOWN": result += n; break;
                case "LEFT": result--; break;
                case "RIGHT": result++; break;
                default: break;
            }
        }
        return result;
    }
    public (int row, int col) GetCoord(int input, int n)
    {
        return (input / n, input % n);
    }

    public static TheoryData<int, string[], int> TestData => new()
    {
        {2, ["RIGHT","DOWN"], 3},
        {3, ["DOWN","RIGHT","UP"], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int size, string[] input, int expected)
    {
        var actual = FinalPositionOfSnake(size, input);
        Assert.Equal(expected, actual);
    }
}