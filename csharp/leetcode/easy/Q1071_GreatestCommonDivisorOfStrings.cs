
class Q1071_GreatestCommonDivisorOfStrings
{
    public string GcdOfStrings(string str1, string str2) 
    {
        return string.Empty;    
    }
}
class Q1071_GreatestCommonDivisorOfStringsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["ABCABC", "ABC", "ABC"],
        ["ABABAB", "ABAB", "AB"],
        ["LEET", "CODE", ""],
    ];
}
public class Q1071_GreatestCommonDivisorOfStringsTests
{
    [Theory]
    [ClassData(typeof(Q1071_GreatestCommonDivisorOfStringsTestData))]
    public void OfficialTestCases(string input1, string input2, string expected)
    {
        var sut = new Q1071_GreatestCommonDivisorOfStrings();
        var actual = sut.GcdOfStrings(input1, input2);
        Assert.Equal(expected, actual);
    }
}