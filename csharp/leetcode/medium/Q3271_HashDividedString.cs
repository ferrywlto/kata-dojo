public class Q3271_HashDividedString
{
    // TC: O(n). n scale with length of s
    // SC: O(n), to store the result
    public string StringHash(string s, int k)
    {
        var result = new char[s.Length / k];
        var groupSum = 0;
        for (var i = 0; i < s.Length; i++)
        {
            groupSum += s[i] - 'a';

            if (i % k == k - 1)
            {
                result[i / k] = (char)((groupSum % 26) + 'a');
                groupSum = 0;
            }
        }
        return new string(result);
    }
    public static TheoryData<string, int, string> TestData => new()
    {
        {"abcd", 2, "bf"},
        {"mxz", 3, "i"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, string expected)
    {
        var actual = StringHash(input, k);
        Assert.Equal(expected, actual);
    }
}
