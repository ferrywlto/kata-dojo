public class Q3014_MinNumberOfPushesToTypeWordI
{
    // TC: O(1) obviously
    // SC: O(1)
    public int MinimumPushes(string word)
    {
        // 26 chars / 8 keys
        // 24 chars / each key has 3
        // 6 keys contains 3, 2 keys contains 4
        var first8 = 8;
        var second8 = 16;
        var third8 = 24;

        var len = word.Length;
        if (len > 24)
        {
            return first8 + second8 + third8 + (len - 24) * 4;
        }
        else if (len > 16)
        {
            return first8 + second8 + (len - 16) * 3;
        }
        else if (len > 8)
        {
            return first8 + (len - 8) * 2;
        }
        else
        {
            return len;
        }
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"abcde", 5},
        {"xycdefghij", 12},
        {"abhrlngxyjkezwcm", 24},
        {"abhrlngxyjkezwcmd", 27},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinimumPushes(input);
        Assert.Equal(expected, actual);
    }
}