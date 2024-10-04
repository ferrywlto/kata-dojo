public class Q2053_KthDistinctStringInArray
{
    // TC: O(n + m), n scale with length of arr plus m unique values in arr
    // SC: O(m + j), m scale with unique values in arr plus j values that exist more than once 
    public string KthDistinct(string[] arr, int k)
    {
        var setAll = new HashSet<string>();
        var setDup = new HashSet<string>();
        foreach(var s in arr)
        {
            if (!setAll.Add(s)) setDup.Add(s);
        }
        var passed = 0;
        foreach(var s in setAll)
        {
            if(setDup.Add(s))
            {
                passed++;
                if (passed == k) return s;
            }
        }
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