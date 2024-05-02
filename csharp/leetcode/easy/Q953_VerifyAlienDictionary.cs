class Q953_VerifyAlienDictionary
{
    public bool IsAlienSorted(string[] words, string order)
    {
        return false;
    }
}

class Q953_VerifyAlienDictionaryTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new string[] {"hello","leetcode"}, "hlabcdefgijkmnopqrstuvwxyz", true],
        [new string[] {"word","world","row"}, "worldabcefghijkmnpqstuvxyz", false],
        [new string[] {"apple","app"}, "abcdefghijklmnopqrstuvwxyz", false],
    ];
}

public class Q953_VerifyAlienDictionaryTests
{
    [Theory]
    [ClassData(typeof(Q953_VerifyAlienDictionaryTestData))]
    public void OfficialTestCases(string[] input, string order, bool expected)
    {
        var sut = new Q953_VerifyAlienDictionary();
        var actual = sut.IsAlienSorted(input, order);
        Assert.Equal(expected, actual);
    }
}