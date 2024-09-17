class Q1897_RedistributeCharactersTomakeAllStringsEqual
{
    public bool MakeEqual(string[] words)
    {
        return false;
    }
}
class Q1897_RedistributeCharactersTomakeAllStringsEqualTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new string[] {"abc","aabc","bc"}, true],
        [new string[] {"ab", "a"}, false],
    ];
}
public class Q1897_RedistributeCharactersTomakeAllStringsEqualTests
{
    [Theory]
    [ClassData(typeof(Q1897_RedistributeCharactersTomakeAllStringsEqualTestData))]
    public void OfficialTestCases(string[] input, bool expected)
    {
        var sut = new Q1897_RedistributeCharactersTomakeAllStringsEqual();
        var actual = sut.MakeEqual(input);
        Assert.Equal(expected, actual);
    }
}