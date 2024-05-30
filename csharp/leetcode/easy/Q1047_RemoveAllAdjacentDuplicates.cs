class Q1047_RemoveAllAdjacentDuplicates
{
    public string RemoveDuplicates(string s)
    {
        return string.Empty;
    }
}
class Q1047_RemoveAllAdjacentDuplicatesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["abbaca", "ca"],
        ["azxxzy", "ay"],
    ];
}
public class Q1047_RemoveAllAdjacentDuplicatesTests
{
    [Theory]
    [ClassData(typeof(Q1047_RemoveAllAdjacentDuplicatesTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1047_RemoveAllAdjacentDuplicates();
        var actual = sut.RemoveDuplicates(input);
        Assert.Equal(expected, actual);
    }
}