public class Q197_RisingTemperature : SqlQuestion
{
    public override string Query =>
    """
    SELECT w1.id 
    FROM Weather w1, Weather w2 
    WHERE w1.recordDate = Date(w2.recordDate, '+1 days') 
    AND w1.temperature > w2.temperature; 
    """;
}

public class Q197_RisingTemperatureTestData : TestData
{
    protected override List<object[]> Data =>
    [[
        """
        INSERT INTO Weather VALUES 
        (1, '2015-01-01', 10),
        (2, '2015-01-02', 25),
        (3, '2015-01-03', 20),
        (4, '2015-01-04', 30);
        """
    ]];
}

public class Q197_RisingTemperatureTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Weather (id INT, recordDate DATE, temperature INT);
    """;

    [Theory]
    [ClassData(typeof(Q197_RisingTemperatureTestData))]
    public override void OfficialTestCases(string input)
    {
        ArrangeTestData(input);

        var sut = new Q197_RisingTemperature();
        var result = ExecuteQuery(sut.Query);

        Assert.True(result.Read());
        Assert.Equal(2, result.GetInt32(0));

        Assert.True(result.Read());
        Assert.Equal(4, result.GetInt32(0));
    }
}