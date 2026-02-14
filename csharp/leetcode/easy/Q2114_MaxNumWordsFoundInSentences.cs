public class Q2114_MaxNumWordsFOundInSentences
{
    // TC: O(n), n scale with length of sentences
    // SC: O(1), space used does not scale with input, avoid intermediate array creation in Split()
    public int MostWordsFound(string[] sentences)
    {
        var maxWords = 0;
        foreach (var s in sentences)
        {
            var words = 0;
            foreach (var c in s)
            {
                if (c == ' ') words++;
            }
            if (s[^1] != ' ') words++;
            if (words > maxWords) maxWords = words;
        }
        return maxWords;
    }
    public static List<object[]> TestData =>
    [
        [
            new string[]
            {
                "alice and bob love leetcode",
                "i think so too",
                "this is great thanks very much",
            }, 6
        ],
        [
            new string[]
            {
                "please wait",
                "continue to fight",
                "continue to win"
            }, 3
        ],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int expected)
    {
        var actual = MostWordsFound(input);
        Assert.Equal(expected, actual);
    }
}
