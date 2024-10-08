public class Q2085_CountCommonWordsWithOneOccurance
{
    public int CountWords(string[] words1, string[] words2)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new string[] { "leetcode", "is", "amazing", "as", "is" }, new string[] {"amazing","leetcode","is"}, 2],
        [new string[] { "b","bb","bbb" }, new string[] {"a","aa","aaa"}, 0],
        [new string[] { "a","ab" }, new string[] {"a","a","a","ab"}, 1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input1, string[] input2, int expected)
    {
        var actual = CountWords(input1, input2);
        Assert.Equal(expected, actual);
    }
}