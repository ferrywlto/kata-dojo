
class Q1002_FindCommonCharacters
{

    public IList<string> CommonChars(string[] words) {
        return [];
    }
}

class Q1002_FindCommonCharactersTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new string[] {"bella","label","roller"}, new string[] {"e","l","l"}],
        [new string[] {"cool","lock","cook"}, new string[] {"c","o"}],
    ];
}

public class Q1002_FindCommonCharactersTests
{
    [Theory]
    [ClassData(typeof(Q1002_FindCommonCharactersTestData))]
    public void OfficialTestCases(string[] input, string[] expected)
    {
        var sut = new Q1002_FindCommonCharacters();
        var actual = sut.CommonChars(input);
        Assert.Equal(expected, actual);
    }
}