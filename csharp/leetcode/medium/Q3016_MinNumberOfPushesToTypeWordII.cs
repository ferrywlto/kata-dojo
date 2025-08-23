public class Q3016_MinNumberOfPushesToTypeWordII
{
    public int MinimumPushes(string word)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"abcde", 5},
        {"xyzxyzxyzxyz", 13},
        {"aabbccddeeffgghhiiiiii", 24},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void MinimumPushes_ShouldReturnExpectedResult(string word, int expected)
    {
        var result = MinimumPushes(word);
        Assert.Equal(expected, result);
    }
}
