public class Q2085_CountCommonWordsWithOneOccurance
{
    public int CountWords(string[] words1, string[] words2)
    {
        // not that efficient way
        var set1 = words1
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count())
            .Where(x => x.Value == 1)
            .Select(x => x.Key)
            .ToHashSet();

        var set2 = words2
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count())
            .Where(x => x.Value == 1)
            .Select(x => x.Key)
            .ToHashSet();

        return set1.Intersect(set2).Count();
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