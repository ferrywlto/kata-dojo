namespace dojo.leetcode;

public class Q28_NeedleInHaystackTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["sadbutsad", "sad", 0],
        ["leetcode", "leeto", -1],
    ];
}

public class Q28_NeedleInHaystackTests
{
    [Theory]
    [ClassData(typeof(Q28_NeedleInHaystackTestData))]
    public void OfficialTestCases(string haystack, string needle, int expected)
    {
        var sut = new Q28_NeedleInHaystack();
        var actual = sut.StrStr(haystack, needle);
        Assert.Equal(expected, actual);
    }
}

public class Q28_NeedleInHaystack
{

    // Speed: 39ms (99.54%), Memory: 38.77MB (6.67%)
    public int StrStr(string haystack, string needle)
    {
        if (needle.Length == 0 || haystack.Length == 0) return -1;
        if (needle.Length > haystack.Length) return -1;

        return haystack.IndexOf(needle);
    }
    // Speed: 41ms (99.31%), Memory: 37.1MB (18.47%)
    // This use a char by char comparison instead of using the built-in function.
    public int StrStr2(string haystack, string needle)
    {
        if (needle.Length == 0 || haystack.Length == 0) return -1;
        if (needle.Length > haystack.Length) return -1;

        ushort idx = 0;
        for (ushort i = 0; i < haystack.Length; i++)
        {
            if (haystack[i] == needle[idx])
            {
                idx++;
                if (idx == needle.Length)
                {
                    return i - idx + 1;
                }
            }
            else
            {
                i -= idx;
                idx = 0;
            }
        }
        return -1;
    }
}