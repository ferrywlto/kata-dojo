namespace dojo.leetcode;

public class Q595_BigCountries : SqlQuestion
{
    public override string Query => 
    """
    SELECT name, population, area
    FROM World
    WHERE population >= 25000000
    OR area >= 3000000;
    """;
}

public class Q595_BigCountriesTestData : TestData
{
    protected override List<object[]> Data => 
    [[
        """
        INSERT INTO World VALUES
        ('Afghanistan', 'Asia', 652230, 25500100, 20343000000),
        ('Albania', 'Europe', 28748, 2831741, 12960000000),
        ('Algeria', 'Africa', 2381741, 37100000, 188681000000),
        ('Andorra', 'Europe', 468, 78115, 3712000000),
        ('Angola', 'Africa', 1246700, 20609294, 100990000000);
        """
    ]];
}

public class Q595_BigCountriesTests(ITestOutputHelper output) : DatabaseTest(output) 
{
    protected override string TestSchema => 
    """
    CREATE TABLE IF NOT EXISTS World (name VARCHAR, continent VARCHAR, area INT, population INT, gdp BIGINT);
    """;

    [Theory]
    [ClassData(typeof(Q595_BigCountriesTestData))]
    public void OfficialTestCases(string testDataSql)
    {
        InputTestData(testDataSql);

        var sut = new Q595_BigCountries();
        var reader = ExecuteQuery(sut.Query);

        Assert.True(reader.HasRows);
        Assert.Equal(3, reader.FieldCount);
        Assert.Equal("name", reader.GetName(0));
        Assert.Equal("population", reader.GetName(1));
        Assert.Equal("area", reader.GetName(2));

        Assert.True(reader.Read());
        Assert.Equal("Afghanistan", reader.GetString(0));
        Assert.Equal(25500100, reader.GetInt32(1));
        Assert.Equal(652230, reader.GetInt32(2));

        Assert.True(reader.Read());
        Assert.Equal("Algeria", reader.GetString(0));
        Assert.Equal(37100000, reader.GetInt32(1));
        Assert.Equal(2381741, reader.GetInt32(2));
    }
}