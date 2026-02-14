public class Q2011_FinalValueOfVariableAfterPerformingOperations
{
    // TC: O(n), n scale with length of operations
    // SC: O(1), space used does not scale with input
    public int FinalValueAfterOperations(string[] operations)
    {
        var result = 0;
        foreach (var op in operations)
        {
            if (op[1] == '+') result++;
            else result--;
        }
        return result;
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
