using System.Text;

class Q1375_GenerateStringWithCharactersHaveOddCounts
{
    // TC: O(n), it have to generate n characters from Enumerable.Repeat()
    // SC: O(n), it have to hold the result of length n
    public string GenerateTheString(int n)
    {
        var sb = new StringBuilder();
        if (n % 2 != 0) sb.Append('a', n);
        // an even number - 1 is always odd, and 1 is odd
        else sb.Append('a', n - 1).Append('b');
        return sb.ToString();
    }
}
class Q1375_GenerateStringWithCharactersHaveOddCountsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [4, "pppz"],
        [2, "xy"],
        [3, "abc"],
        [6, "aaaaab"],
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
