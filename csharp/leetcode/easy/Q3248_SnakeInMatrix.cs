public class Q3248_SnakeInMatrix
{
    public int FinalPositionOfSnake(int n, IList<string> commands)
    {
        return 0;
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