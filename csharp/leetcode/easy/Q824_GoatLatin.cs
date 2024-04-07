
namespace dojo.leetcode;

public class Q824_GoatLatin
{
    public string ToGoatLatin(string sentence) 
    {
        return string.Empty;    
    }
}

public class Q824_GoatLatinTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["I speak Goat Latin", "Imaa peaksmaaa oatGmaaaa atinLmaaaaa"],
        ["The quick brown fox jumped over the lazy dog", "heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa"],
    ];
}

public class Q824_GoatLatinTests
{
    [Theory]
    [ClassData(typeof(Q824_GoatLatinTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q824_GoatLatin();
        var actual = sut.ToGoatLatin(input);
        Assert.Equal(expected, actual);
    }
}