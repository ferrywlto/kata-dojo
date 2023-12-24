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

// Speed: 39ms (99.54%), Memory: 38.77MB (6.67%)
public class Q28_NeedleInHaystack {
    public int StrStr(string haystack, string needle) {
        if (needle.Length == 0 || haystack.Length == 0) return -1;
        if (needle.Length > haystack.Length) return -1;

        return haystack.IndexOf(needle);
    }
}