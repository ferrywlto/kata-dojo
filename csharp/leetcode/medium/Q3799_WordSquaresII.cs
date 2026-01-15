public class Q3799_WordSquaresII
{
    public IList<IList<string>> WordSquares(string[] words)
    {
        return [];
    }
    public static TheoryData<string[], string[][]> TestData => new()
    {
        {
            ["able","area","echo","also"],
            [["able","area","echo","also"],["area","able","also","echo"]]
        },
        {
            ["code","cafe","eden","edge"],
            []
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string[][] expected)
    {
        var actual = WordSquares(input);
        Assert.Equal(expected, actual);
    }
}
