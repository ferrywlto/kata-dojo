namespace dojo.leetcode;

public class Q500_KeyboarRow
{
    public string[] FindWords(string[] words)
    {
        return [];        
    }
}

public class Q500_KeyboarRowTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new string[] {"Hello", "Alaska", "Dad", "Peace"}, new string[] {"Alaska", "Dad"}],
        [new string[] {"omk"}, new string[] {}],
        [new string[] {"adsdf", "sfd"}, new string[] {"adsdf", "sfd"}],
    ];
}

public class Q500_KeyboarRowTests
{
    [Theory]
    [ClassData(typeof(Q500_KeyboarRowTestData))]
    public void OfficialTestCases(string[] words, string[] expected)
    {
        var sut = new Q500_KeyboarRow();
        var actual = sut.FindWords(words);
        Assert.Equal(expected, actual);
    }
}