public class Q2047_NumValidWordsInSentence
{
    public int CountValidWords(string sentence)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        ["cat and  dog", 3],
        ["!this  1-s b8d!", 0],
        ["alice and  bob are playing stone-game10", 5],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = CountValidWords(input);
        Assert.Equal(expected, actual);
    }
}