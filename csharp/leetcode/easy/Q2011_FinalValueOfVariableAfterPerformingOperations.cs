public class Q2011_FinalValueOfVariableAfterPerformingOperations
{
    public int FinalValueAfterOperations(string[] operations)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"--X","X++","X++"}, 1],
        [new string[] {"++X","++X","X++"}, 3],
        [new string[] {"X++","++X","--X","X--"}, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int expected)
    {
        var actual = FinalValueAfterOperations(input);
        Assert.Equal(expected, actual);
    }
}