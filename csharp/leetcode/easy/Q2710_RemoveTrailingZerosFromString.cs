public class Q2710_RemoveTrailingZerosFromString
{
    // TC: O(n), n scale with length of num
    // SC: O(1) if not count the result string, O(n) otherwise 
    public string RemoveTrailingZeros(string num)
    {
        var lastIdx = -1;
        for (var i = num.Length - 1; i >= 0; i--)
        {
            if (num[i] != '0')
            {
                lastIdx = i + 1;
                break;
            }
        }
        return new string(num.ToCharArray(), 0, lastIdx);
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"51230100", "512301"},
        {"123", "123"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = RemoveTrailingZeros(input);
        Assert.Equal(expected, actual);
    }
}