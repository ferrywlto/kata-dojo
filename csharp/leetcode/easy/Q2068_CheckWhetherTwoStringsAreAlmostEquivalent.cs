public class Q2068_CheckWhetherTwoStringsAreAlmostEquivalent
{
    // TC: O(n), n scale with length of word1
    // SC: O(1), space used does not scale with input
    public bool CheckAlmostEquivalent(string word1, string word2)
    {
        var freq1 = new int[26];
        foreach(var c in word1) freq1[c - 'a']++;

        var freq2 = new int[26];
        foreach(var c in word2) freq2[c - 'a']++;

        for(var i=0; i<freq1.Length; i++)
        {
            var diff = Math.Abs(freq1[i] - freq2[i]);
            if (diff > 3) return false;
        }
        return true;
    }
    public static List<object[]> TestData =>
    [
        ["aaaa", "bccb", false],
        ["abcdeef", "abaaacc", true],
        ["cccddabba", "babababab", true],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input1, string input2, bool expected)
    {
        var actual = CheckAlmostEquivalent(input1, input2);
        Assert.Equal(expected, actual);
    }
}