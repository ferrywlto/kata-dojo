public class Q3498_ReverseDegreeOfString
{
    public int ReverseDegree(string s)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"abc", 148},
        {"zaza", 160},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = ReverseDegree(input);
        Assert.Equal(expected, actual);
    }
}