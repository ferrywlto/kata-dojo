public class Q3889_MirrorFrequencyDistance
{
    public int MirrorFrequency(string s)
    {
        return 0;
    }

    public static TheoryData<string, int> TestData => new()
    {
        { "ab1z9", 3 },
        { "4m7n", 2 },
        { "byby", 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MirrorFrequency(input);
        Assert.Equal(expected, actual);
    }
}
