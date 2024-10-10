public class Q2114_MaxNumWordsFOundInSentences
{
    // TC: O(n), n scale with length of sentences
    // SC: O(n), as each sentence need to split into array to count words
    public int MostWordsFound(string[] sentences)
    {
        var maxWords = 0;
        foreach(var s in sentences)
        {
            var words = s.Split(' ').Length;
            if (words> maxWords) maxWords = words;
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