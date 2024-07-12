
class Q1422_MaxScoreAfterSpiltString
{
    public int MaxScore(string s)
    {
        return 0;
    }
}
class Q1422_MaxScoreAfterSpiltStringTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["011101", 5],
        ["00111", 5],
        ["1111", 3],
    ];
}
public class Q1422_MaxScoreAfterSpiltStringTests
{
    [Theory]
    [ClassData(typeof(Q1422_MaxScoreAfterSpiltStringTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1422_MaxScoreAfterSpiltString();
        var actual = sut.MaxScore(input);
        Assert.Equal(expected, actual);
    }
}