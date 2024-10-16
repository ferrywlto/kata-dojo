public class Q2068_CheckWhetherTwoStringsAreAlmostEquivalent
{
    public bool CheckAlmostEquivalent(string word1, string word2)
    {
        return false;
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