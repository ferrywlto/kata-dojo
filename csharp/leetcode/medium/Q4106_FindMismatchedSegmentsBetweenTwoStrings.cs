public class Q4106_FindMismatchedSegmentsBetweenTwoStrings
{
    public IList<IList<string>> FindMismatchedSegments(string s1, string s2)
    {
        return [];
    }

    public static TheoryData<string, string, IList<List<string>>> TestData => new()
    {
        { "earth", "empty", [["ar", "mp"], ["h", "y"]] },
        { "action", "nation", [["ac", "na"]] },
        { "hot", "hot", [] }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s1, string s2, IList<List<string>> expected)
    {
        var actual = FindMismatchedSegments(s1, s2);
        Assert.Equal(expected, actual);
    }
}
