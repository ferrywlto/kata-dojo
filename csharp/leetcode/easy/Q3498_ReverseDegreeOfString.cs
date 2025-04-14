public class Q3498_ReverseDegreeOfString
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public int ReverseDegree(string s)
    {
        var map = new int[26];
        var start = 26;
        for (var i = 0; i < map.Length; i++)
        {
            map[i] = start--;
        }

        var result = 0;
        for (var i = 0; i < s.Length; i++)
        {
            var idx = s[i] - 'a';
            var revIdx = map[idx];
            result += (i + 1) * revIdx;
        }
        return result;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"abc", 148},
        {"zaza", 160},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = ReverseDegree(input);
        Assert.Equal(expected, actual);
    }
}