class Q1662_CheckIfTwoStringArraysAreEquivalent
{
    public bool ArrayStringsAreEqual(string[] word1, string[] word2)
    {
        return false;
    }
}
class Q1662_CheckIfTwoStringArraysAreEquivalentTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new string[] {"ab", "c"}, new string[] {"a", "bc"}, true],
        [new string[] {"a", "cb"}, new string[] {"ab", "c"}, false],
        [new string[] {"abc", "d", "defg"}, new string[] {"abcddefg"}, true],
    ];
}
public class Q1662_CheckIfTwoStringArraysAreEquivalentTests
{
    [Theory]
    [ClassData(typeof(Q1662_CheckIfTwoStringArraysAreEquivalentTestData))]
    public void OfficialTestCases(string[] input1, string[] input2, bool expected)
    {
        var sut = new Q1662_CheckIfTwoStringArraysAreEquivalent();
        var actual = sut.ArrayStringsAreEqual(input1, input2);
        Assert.Equal(expected, actual);
    }
}