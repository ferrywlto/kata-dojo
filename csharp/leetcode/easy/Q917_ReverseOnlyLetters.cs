
class Q917_ReverseOnlyLetters
{
    public string ReverseOnlyLetters(string s) 
    {
        return string.Empty;    
    }
}

class Q917_ReverseOnlyLettersTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["ab-cd", "dc-ba"],
        ["a-bC-dEf-ghIj", "j-Ih-gfE-dCba"],
        ["Test1ng-Leet=code-Q!", "Qedo1ct-eeLg=ntse-T!"],
    ];
}

public class Q917_ReverseOnlyLettersTests
{
    [Theory]
    [ClassData(typeof(Q917_ReverseOnlyLettersTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q917_ReverseOnlyLetters();
        var actual = sut.ReverseOnlyLetters(input);
        Assert.Equal(expected, actual);
    }
}