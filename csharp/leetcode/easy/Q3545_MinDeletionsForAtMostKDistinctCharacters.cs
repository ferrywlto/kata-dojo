public class Q3545_MinDeletionsForAtMostKDistinctCharacters
{
    public int MinDeletion(string s, int k)
    {
        return 0;
    }
    public static TheoryData<string, int, int> TestData => new()
    {
        {"abc", 2, 1},
        {"aabb", 2, 0},
        {"yyyzz", 1, 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, int expected)
    {
        var actual = MinDeletion(input, k);
        Assert.Equal(expected, actual);
    }
}