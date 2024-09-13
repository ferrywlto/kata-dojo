class Q1854_MaxPopulationYear
{
    // TC: O(n*m), where n is length of logs, and m is length of logs*2 for birth and died
    // SC: O(m), where m is length of logs * 2
    public int MaximumPopulation(int[][] logs)
    {
        var years = new HashSet<int>();
        foreach (var l in logs)
        {
            years.Add(l[0]);
            years.Add(l[1]);
        }
        var minYear = int.MaxValue;
        var maxPopulation = 0;
        foreach (var year in years)
        {
            var population = 0;
            foreach (var l in logs)
            {
                if (l[0] <= year && l[1] > year) population++;
            }
            if (population > maxPopulation)
            {
                maxPopulation = population;
                minYear = year;
            }
            else if (population == maxPopulation && year < minYear)
            {
                minYear = year;
            }
        }
        return minYear;
    }
}
class Q1854_MaxPopulationYearTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] { [1993,1999],[2000,2010] }, 1993],
        [new int[][] { [1950,1961],[1960,1971],[1970,1981]}, 1960],
        [new int[][] {
            [2033,2034],
            [2039,2047],
            [1998,2042],
            [2047,2048],
            [2025,2029],
            [2005,2044],
            [1990,1992],
            [1952,1956],
            [1984,2014]
        }, 2005],
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