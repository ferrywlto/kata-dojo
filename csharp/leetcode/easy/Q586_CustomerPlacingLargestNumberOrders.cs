

namespace dojo.leetcode;

public class Q586_CustomerPlacingLargestNumberOrders : SqlQuestion
{
    public override string Query => 
    """
    SELECT 1;
    """;
}

public class Q586_CustomerPlacingLargestNumberOrdersTestData : TestData
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

        Assert.True(reader.HasRows);
        Assert.Equal(1, reader.FieldCount);
        Assert.Equal("customer_number", reader.GetName(0));

        Assert.True(reader.Read());
        Assert.Equal(3, reader.GetInt32(0));
        Assert.False(reader.Read());
    }
}