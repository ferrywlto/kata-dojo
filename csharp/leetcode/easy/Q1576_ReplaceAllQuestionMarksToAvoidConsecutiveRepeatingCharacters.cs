class Q1576_ReplaceAllQuestionMarksToAvoidConsecutiveRepeatingCharacters
{
    public string ModifyString(string s) 
    {
        return string.Empty;    
    }    
}
class Q1576_ReplaceAllQuestionMarksToAvoidConsecutiveRepeatingCharactersTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["?zs", "azs"],
        ["ubv?w", "ubvaw"],
    ];
}
public class Q1576_ReplaceAllQuestionMarksToAvoidConsecutiveRepeatingCharactersTests
{
    [Theory]
    [ClassData(typeof(Q1576_ReplaceAllQuestionMarksToAvoidConsecutiveRepeatingCharactersTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1576_ReplaceAllQuestionMarksToAvoidConsecutiveRepeatingCharacters();
        var actual = sut.ModifyString(input);
        Assert.Equal(expected, actual);
    }
}