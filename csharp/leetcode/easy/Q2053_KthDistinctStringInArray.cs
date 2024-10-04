public class Q2053_KthDistinctStringInArray
{
    public string KthDistinct(string[] arr, int k)
    {
        return string.Empty;
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