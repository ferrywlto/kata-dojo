public class Q3136_ValidWord
{
    public bool IsValid(string word)
    {
        return false;
    }
    public static TheoryData<string, bool> TestData => new()
    {
        {"234Adas", true},
        {"b3", false},
        {"a3$e", false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = IsValid(input);
        Assert.Equal(expected, actual);
    }
}