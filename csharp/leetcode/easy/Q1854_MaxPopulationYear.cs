class Q1854_MaxPopulationYear
{
    // TC: O(n + y), where n is length of logs, and y is the number of years in range
    // SC: O(y), where y is range of years
    public int MaximumPopulation(int[][] logs)
    {
        // Range from 1950 to 2050
        int[] populationChanges = new int[101]; 

        foreach (var log in logs)
        {
            // year of birth
            populationChanges[log[0] - 1950]++;
            // year of death
            populationChanges[log[1] - 1950]--;
        }

        int maxPopulation = 0;
        int currentPopulation = 0;
        int minYear = 1950;

        for (int year = 0; year < populationChanges.Length; year++)
        {
            currentPopulation += populationChanges[year];
            if (currentPopulation > maxPopulation)
            {
                maxPopulation = currentPopulation;
                minYear = 1950 + year;
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