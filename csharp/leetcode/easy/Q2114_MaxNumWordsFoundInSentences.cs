public class Q2114_MaxNumWordsFOundInSentences
{
    public int MostWordsFound(string[] sentences)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {
            "alice and bob love leetcode",
            "i think so too",
            "this is great thanks very much",
        }],
        [
            new string[] {
                "please wait",
                "continue to fight",
                "continue to win"
            }
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