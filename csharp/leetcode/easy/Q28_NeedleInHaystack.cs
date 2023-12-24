public class Q28_NeedleInHaystackTests {
    [Theory]
    [InlineData("sadbutsad", "sad", 0)]
    [InlineData("leetcode", "leeto", -1)]
    public void OfficialTestCases(string haystack, string needle, int expected) {
        var sut = new Q28_NeedleInHaystack();
        var actual = sut.StrStr(haystack, needle);
        Assert.Equal(expected, actual);
    }
}

public class Q28_NeedleInHaystack {
    public int StrStr(string haystack, string needle) {
        return 0;
    }
}