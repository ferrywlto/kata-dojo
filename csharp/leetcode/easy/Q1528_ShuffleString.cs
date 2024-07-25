class Q1528_ShuffleString
{
    public string RestoreString(string s, int[] indices)
    {
        return string.Empty;
    }
}
class Q1528_ShuffleStringTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["codeleet", new int[] {4,5,6,7,0,2,1,3}, "leetcode"],
        ["abc", new int[] {0,1,2}, "abc"],
    ];
}
public class Q1528_ShuffleStringTests
{
    [Theory]
    [ClassData(typeof(Q1528_ShuffleStringTestData))]
    public void OfficialTestCases(string input, int[] indices, string expected)
    {
        var sut = new Q1528_ShuffleString();
        var actual = sut.RestoreString(input, indices);
        Assert.Equal(expected, actual);
    }
}