class Q1790_CheckIfOneStringSwapCanMakeEqual
{
    public bool AreAlmostEqual(string s1, string s2)
    {
        return false;
    }
}
class Q1790_CheckIfOneStringSwapCanMakeEqualTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["bank", "kanb", true],
        ["attack", "defend", false],
        ["kelb", "kelb", true],
    ];
}
public class Q1790_CheckIfOneStringSwapCanMakeEqualTests
{
    [Theory]
    [ClassData(typeof(Q1790_CheckIfOneStringSwapCanMakeEqualTestData))]
    public void OfficialTestCases(string s1, string s2, bool expected)
    {
        var sut = new Q1790_CheckIfOneStringSwapCanMakeEqual();
        var actual = sut.AreAlmostEqual(s1, s2);
        Assert.Equal(expected, actual);
    }
}