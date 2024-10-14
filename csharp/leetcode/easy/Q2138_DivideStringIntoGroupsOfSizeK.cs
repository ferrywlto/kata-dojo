public class Q2138_DivideStringIntoGroupsOfSizeK
{
    // TC: O(n), n scale with length of s
    // SC: O(m), m scale with length of s / k;
    public string[] DivideString(string s, int k, char fill)
    {
        var result = new List<string>();
        var len = s.Length;
        for (var i = 0; i < len; i += k)
        {
            if (i + k > len)
            {
                var remaining = len - i;
                var tail = string.Join(string.Empty, Enumerable.Repeat(fill, k - remaining));
                result.Add(s[i..(i + remaining)] + tail);
            }
            else result.Add(s[i..(i + k)]);
        }
        return result.ToArray();
    }
    public static List<object[]> TestData =>
    [
        ["abcdefghi", 3, 'x', new string[] {"abc","def","ghi"}],
        ["abcdefghij", 3, 'x', new string[] {"abc","def","ghi","jxx"}],
        ["ctoyjrwtngqwt", 8, 'n', new string[] {"ctoyjrwt","ngqwtnnn"}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, char fill, string[] expected)
    {
        var actual = DivideString(input, k, fill);
        Assert.Equal(expected, actual);
    }
}