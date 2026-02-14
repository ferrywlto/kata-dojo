public class Q3019_NumOfChangingKeys
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public int CountKeyChanges(string s)
    {
        var result = 0;
        for (var i = 1; i < s.Length; i++)
        {
            if (char.ToLower(s[i]) != char.ToLower(s[i - 1]))
            {
                result++;
            }
        }
        return result;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"aAbBcC", 2},
        {"AaAaAaaA", 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = CountKeyChanges(input);
        Assert.Equal(expected, actual);
    }
}
