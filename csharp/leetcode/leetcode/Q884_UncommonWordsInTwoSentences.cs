
public class Q884_UncommonWordsInTwoSentences
{
    public string[] UncommonFromSentences(string s1, string s2)
    {
        return [];
    }
}

public class Q884_UncommonWordsInTwoSentencesTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["this apple is sweet", "this apple is sour", new string[] {"sweet","sour"}],
        ["apple apple", "banana", new string[] {"banana"}],
    ];
}

public class Q884_UncommonWordsInTwoSentencesTests
{
    [Theory]
    [ClassData(typeof(Q884_UncommonWordsInTwoSentencesTestData))]
    public void OfficialTestCases(string input1, string input2, string[] expected)
    {
        var sut = new Q884_UncommonWordsInTwoSentences();
        var actual = sut.UncommonFromSentences(input1, input2);
        Assert.Equal(expected, actual);
    }
}