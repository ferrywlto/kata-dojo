class Q1624_LargestSubstringBetweenTwoEqualCharacters
{
    // TC: O(n), where n is length of s
    // SC: O(n), where n is number of unique characters in s
    public int MaxLengthBetweenEqualCharacters(string s)
    {
        var maxLength = -1;
        var dict = new Dictionary<char, int[]>();

        for (var i = 0; i < s.Length; i++)
        {
            if (dict.TryGetValue(s[i], out var value))
            {
                dict[s[i]][1] = i;
                var diff = dict[s[i]][1] - dict[s[i]][0] - 1;
                if (diff > maxLength) maxLength = diff;
            }
            else dict.Add(s[i], [i, -1]);
        }
        return maxLength;
    }
}
class Q1624_LargestSubstringBetweenTwoEqualCharactersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["aa", 0],
        ["abca", 2],
        ["cbzxy", -1],
        ["mgntdygtxrvxjnwksqhxuxtrv", 18],
    ];
}
public class Q1624_LargestSubstringBetweenTwoEqualCharactersTests
{
    [Theory]
    [ClassData(typeof(Q1624_LargestSubstringBetweenTwoEqualCharactersTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1624_LargestSubstringBetweenTwoEqualCharacters();
        var actual = sut.MaxLengthBetweenEqualCharacters(input);
        Assert.Equal(expected, actual);
    }
}
