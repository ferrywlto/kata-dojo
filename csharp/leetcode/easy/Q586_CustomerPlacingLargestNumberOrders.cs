class Q586_CustomerPlacingLargestNumberOrders : SqlQuestion
{
    public override string Query => 
    // This SQL is for PostgreSQL as some syntax of T-SQL are not supported in SQLite 
    """
    SELECT customer_number 
    FROM Orders
    GROUP BY customer_number
    ORDER BY count(order_number) DESC
    LIMIT 1;
    """;
}

class Q586_CustomerPlacingLargestNumberOrdersTestData : TestData
{
    protected override List<object[]> Data => 
    [[
        """
        INSERT INTO Orders VALUES
        (1,1),
        (2,2),
        (3,3),
        (4,3);
        """
    ]];
}
[Trait("QuestionType", "SQL")]
public class Q586_CustomerPlacingLargestNumberOrdersTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema => 
    """
    CREATE TABLE IF NOT EXISTS Orders (order_number INT, customer_number INT);
    """;

    [Theory]
    [ClassData(typeof(Q586_CustomerPlacingLargestNumberOrdersTestData))]
    public override void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);

        var sut = new Q586_CustomerPlacingLargestNumberOrders();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["customer_number"]);

        Assert.True(reader.Read());
        Assert.Equal(3, reader.GetInt32(0));
        Assert.False(reader.Read());
    }
}