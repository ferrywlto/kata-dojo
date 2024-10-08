public class Q2085_CountCommonWordsWithOneOccurance
{
    // TC: O(n+m), where n sacle with length of words1 and m scales with length of words2
    // SC: O(n+m), for the dictionary sizes
    public int CountWords(string[] words1, string[] words2)
    {
        var set1 = words1
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());

        var set2 = words2
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());

        var bothExistCount = 0;
        foreach(var pair in set1)
        {
            if(pair.Value == 1) 
            {
                if(set2.TryGetValue(pair.Key, out var value))
                {
                    if (value == 1) bothExistCount++;
                }
            }
        }

        return bothExistCount;
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