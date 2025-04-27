public class Q3211_GenerateBinaryStringsWithoutAdjacentZeros
{
    // TC: O(n^2), n scale with size of n
    // SC: O(n)
    // It could be faster if use recursion
    public IList<string> ValidStrings(int n)
    {
        var len = 1;
        var dict = new Dictionary<int, List<string>>
        {
            { 1, ["0", "1"] }
        };

        while (len < n)
        {
            var prev = dict[len];
            var next = new List<string>();
            for (var i = 0; i < prev.Count; i++)
            {
                var str = prev[i];

                if (str[^1] == '1')
                {
                    next.Add(str + '0');
                }
                next.Add(str + '1');
            }
            dict.Add(++len, next);
        }
        return dict[len];
    }
    public static TheoryData<int, string[]> TestData => new()
    {
        {3, ["010","011","101","110","111"]},
        {1, ["0","1"]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, string[] expected)
    {
        var actual = ValidStrings(input);
        Assert.Equal(expected, actual);
    }
}