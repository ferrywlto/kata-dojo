using System.Text;

public class Q824_GoatLatin
{
    // TC: O(n), n is total words in sentence
    // SC: O(n+m), n is average word length, m is number of words
    const string vowels = "aeiouAEIOU";
    public string ToGoatLatin(string sentence) 
    {
        var endA = new StringBuilder("a");
        var words = sentence.Split(" ");
        var stringFactory = new StringBuilder();
        for(var i=0; i<words.Length; i++)
        {
            stringFactory.Clear();
            if(vowels.IndexOf(words[i][0]) > -1)
            {
                stringFactory.Append(words[i]);
            }
            else
            {
                stringFactory.Append(words[i][1..]).Append(words[i][0]);
            }
            stringFactory.Append("ma").Append(endA);
            words[i] = stringFactory.ToString();
            endA.Append('a');
        }
        return string.Join(' ', words);    
    }
}

public class Q824_GoatLatinTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["I speak Goat Latin", "Imaa peaksmaaa oatGmaaaa atinLmaaaaa"],
        ["The quick brown fox jumped over the lazy dog", "heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa"],
        ["Each word consists of lowercase and uppercase letters only", "Eachmaa ordwmaaa onsistscmaaaa ofmaaaaa owercaselmaaaaaa andmaaaaaaa uppercasemaaaaaaaa etterslmaaaaaaaaa onlymaaaaaaaaaa"],
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