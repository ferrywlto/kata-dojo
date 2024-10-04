public class Q2053_KthDistinctStringInArray
{
    // TC: O(n + k), n scale with length of arr plus k
    // SC: O(m), m scale with distinct value in arr
    public string KthDistinct(string[] arr, int k)
    {
        var dict = arr
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());
        var result = dict
            .Where(x => x.Value == 1)
            .Select(x => x.Key);
        if (result.Count() < k) return string.Empty;
        return result
            .Skip(k - 1)
            .First();
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"d","b","c","b","c","a"}, 2, "a"],
        [new string[] {"aaa","aa","a"}, 1, "aaa"],
        [new string[] {"a","b","a"}, 3, string.Empty],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int k, string expected)
    {
        var actual = KthDistinct(input, k);
        Assert.Equal(expected, actual);
    }
}