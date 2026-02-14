class Q1688_CountOfMatchesInTournament
{
    // TC: O(1)
    // SC: O(1), obviously
    public int NumberOfMatches(int n)
    {
        return n - 1;
    }
}
class Q1688_CountOfMatchesInTournamentTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [7, 6],
        [14, 13],
    ];
}
public class Q1688_CountOfMatchesInTournamentTests
{
    [Theory]
    [ClassData(typeof(Q1688_CountOfMatchesInTournamentTestData))]
    public void OfficialTestCases(int n, int expected)
    {
        var sut = new Q1688_CountOfMatchesInTournament();
        var actual = sut.NumberOfMatches(n);
        Assert.Equal(expected, actual);
    }
}
