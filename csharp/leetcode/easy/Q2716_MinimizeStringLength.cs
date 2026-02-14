public class Q2716_MinimizeStringLength
{
    // TC: O(n), worst case all characters are unique
    // SC: O(n), same as time
    public int MinimizedStringLength(string s)
    {
        var uniqueChars = s.ToHashSet();
        return uniqueChars.Count;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"aaabc", 3},
        {"cbbd", 3},
        {"baadccab", 4},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinimizedStringLength(input);
        Assert.Equal(expected, actual);
    }
}
