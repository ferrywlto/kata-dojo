public class Q3884_FirstMatchingCharacterFromBothEnds
{
    public int FirstMatchingIndex(string s)
    {
        return 0;
    }

    public static TheoryData<string, int> TestData => new() { { "abcacbd", 1 }, { "abc", 1 }, { "abcdab", -1 }, };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = FirstMatchingIndex(input);
        Assert.Equal(expected, actual);
    }
}
