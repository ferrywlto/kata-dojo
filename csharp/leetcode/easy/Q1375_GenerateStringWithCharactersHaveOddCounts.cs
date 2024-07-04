
class Q1375_GenerateStringWithCharactersHaveOddCounts
{
    public string GenerateTheString(int n)
    {
        return string.Empty;
    }
}
class Q1375_GenerateStringWithCharactersHaveOddCountsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [4, "pppz"],
        [2, "xy"],
        [7, "holasss"],
    ];
}
public class Q1375_GenerateStringWithCharactersHaveOddCountsTests
{
    [Theory]
    [ClassData(typeof(Q1375_GenerateStringWithCharactersHaveOddCountsTestData))]
    public void OfficialTestCases(int input, string expected)
    {
        var sut = new Q1375_GenerateStringWithCharactersHaveOddCounts();
        var actual = sut.GenerateTheString(input);
        Assert.Equal(actual.Length, input);
        Assert.Equal(IsAllOdd(actual), IsAllOdd(expected));
    }
    private bool IsAllOdd(string input)
    {
        return input.GroupBy(x => x)
            .ToDictionary(grp => grp.Key, grp => grp.Count() % 2 == 1)
            .All(x => x.Value);
    }
}
