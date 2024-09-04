class Q1790_CheckIfOneStringSwapCanMakeEqual
{
    // TC: O(n), where n is the length of s1
    // SC: O(1), space used for c is fixed to 4
    public bool AreAlmostEqual(string s1, string s2)
    {
        var diff = 0;
        var c = new char[4];
        for (var i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {

                if (diff == 0)
                {
                    c[0] = s1[i];
                    c[1] = s2[i];
                }
                else if (diff == 1)
                {
                    c[2] = s1[i];
                    c[3] = s2[i];
                }
                else return false;
                diff++;
            }
        }
        if (diff == 0) return true;
        else if (diff == 2 && c[0] == c[3] && c[1] == c[2]) return true;
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
        ["caa", "aaz", false],
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