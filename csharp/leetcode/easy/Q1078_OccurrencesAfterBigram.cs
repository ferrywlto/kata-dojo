
class Q1078_OccurancesAfterBigram
{
        public string[] FindOcurrences(string text, string first, string second) {
        return [];
    }
}
class Q1078_OccurancesAfterBigramTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["alice is a good girl she is a good student", "a", "good", new string[] {"girl", "student"}],
        ["we will we will rock you", "we", "will", new string[] {"we", "rock"}],
    ];
}
public class Q1078_OccurancesAfterBigramTests
{
    [Theory]
    [ClassData(typeof(Q1078_OccurancesAfterBigramTestData))]
    public void OfficialTestCases(string input, string first, string second, string[] expected)
    {
        var sut = new Q1078_OccurancesAfterBigram();
        var actual = sut.FindOcurrences(input, first, second);
        Assert.Equal(expected, actual);
    }
}