public class Q3461_CheckIfDigitsAreEqualInStringAfterOperationsI
{
    public bool HasSameDigits(string s)
    {
        return false;
    }
    public static TheoryData<string, bool> TestData => new()
    {
        {"3902", true},
        {"34789", false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = HasSameDigits(input);
        Assert.Equal(expected, actual);
    }
}