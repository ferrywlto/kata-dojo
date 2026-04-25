public class Q3884_FirstMatchingCharacterFromBothEnds
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public int FirstMatchingIndex(string s)
    {
        var len = s.Length;
        var idx = 0;
        while (idx <= len / 2)
        {
            if (s[idx] == s[len - idx - 1]) return idx;
            idx++;
        }

        return -1;
    }

    public static TheoryData<string, int> TestData => new() { { "abcacbd", 1 }, { "abc", 1 }, { "abcdab", -1 }, };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = FirstMatchingIndex(input);
        Assert.Equal(expected, actual);
    }
}
