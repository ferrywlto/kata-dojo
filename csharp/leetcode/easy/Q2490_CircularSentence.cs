public class Q2490_CircularSentence
{
    // TC: O(n), n scale with length of sentence
    // SC: O(1), space used does not scale with input
    public bool IsCircularSentence(string sentence)
    {
        if (sentence[0] != sentence[^1]) return false;
        for (var i = 0; i < sentence.Length; i++)
        {
            if (sentence[i] == ' ' && (sentence[i - 1] != sentence[i + 1]))
                return false;
        }
        return true;
    }
    public static List<object[]> TestData =>
    [
        ["leetcode exercises sound delightful", true],
        ["eetcode", true],
        ["Leetcode is cool", false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = IsCircularSentence(input);
        Assert.Equal(expected, actual);
    }
}