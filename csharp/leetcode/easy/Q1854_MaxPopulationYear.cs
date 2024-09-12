class Q1854_MaxPopulationYear
{
    public int MaximumPopulation(int[][] logs)
    {
        return 0;
    }
}
class Q1854_MaxPopulationYearTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] { [1993,1999],[2000,2010] }, 1993],
        [new int[][] { [1950,1961],[1960,1971],[1970,1981]}, 1960],
    ];
}
public class Q1854_MaxPopulationYearTests
{
    [Theory]
    [ClassData(typeof(Q1854_MaxPopulationYearTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q1854_MaxPopulationYear();
        var acutal = sut.MaximumPopulation(input);
        Assert.Equal(expected, acutal);
    }
}