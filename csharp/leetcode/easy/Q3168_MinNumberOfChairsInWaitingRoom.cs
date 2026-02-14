public class Q3168_MinNumberOfChairsInWaitingRoom
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public int MinimumChairs(string s)
    {
        var result = 0;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == 'E') result++;
            else if (result > 0) result--;
        }
        return result;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"EEEEEEE", 7},
        {"ELELEEL", 2},
        {"ELEELEELLL", 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinimumChairs(input);
        Assert.Equal(expected, actual);
    }
}
