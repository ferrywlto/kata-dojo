public class Q3340_CheckBalancedString
{
    // TC: O(n), n sacle with length of num
    // SC: O(1), space used does not scale with input
    public bool IsBalanced(string num)
    {
        var sum = new int[2];
        for (var i = 0; i < num.Length; i++)
        {
            sum[i % 2] += num[i] - '0';
        }
        return sum[0] == sum[1];
    }
    public static TheoryData<string, bool> TestData => new()
    {
        {"1234", false},
        {"24123", true},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = IsBalanced(input);
        Assert.Equal(expected, actual);
    }
}
