public class Q3921_ScoreValidator
{
    public int[] ScoreValidator(string[] events)
    {
        return [];
    }

    public static TheoryData<string[], int[]> TestData => new()
    {
        { ["1", "4", "W", "6", "WD"], [12, 1] },
        { ["WD", "NB", "0", "4", "4"], [10, 1] },
        { ["W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W"], [0, 10] }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int[] expected)
    {
        var actual = ScoreValidator(input);
        Assert.Equal(expected, actual);
    }
}
