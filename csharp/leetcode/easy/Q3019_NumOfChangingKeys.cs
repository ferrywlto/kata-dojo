public class Q3019_NumOfChangingKeys
{
    public int CountKeyChanges(string s)
    {
        return 0;
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