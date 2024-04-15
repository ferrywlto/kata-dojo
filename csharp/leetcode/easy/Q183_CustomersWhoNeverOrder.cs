public class Q183_CustomersWhoNeverOrder : SqlQuestion
{
    public override string Query =>
    """
    SELECT name as Customers 
    FROM Customers 
    WHERE id NOT IN 
    (
        SELECT customerId 
        FROM Orders
    );
    """;
}

public class Q183_CustomersWhoNeverOrderTestData : TestData
{
    protected override List<object[]> Data =>
    [[
        """
        INSERT INTO Customers VALUES 
        (1, 'Joe'),
        (2, 'Henry'),
        (3, 'Sam'),
        (4, 'Max');

        INSERT INTO Orders VALUES
        (1, 3),
        (2, 1);
        """
    ]];
}

public class Q183_CustomersWhoNeverOrderTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Customers (id INT, name VARCHAR);
    CREATE TABLE IF NOT EXISTS Orders (id INT, customerId VARCHAR);
    """;

    [Theory]
    [ClassData(typeof(Q183_CustomersWhoNeverOrderTestData))]
    public override void OfficialTestCases(string input)
    {
        ArrangeTestData(input);

        var sut = new Q183_CustomersWhoNeverOrder();

        var reader = ExecuteQuery(sut.Query);

        Assert.True(reader.HasRows);
        Assert.Equal(1, reader.FieldCount);
        Assert.Equal("Customers", reader.GetName(0));

        Assert.True(reader.Read());
        Assert.Equal("Henry", reader.GetString(0));

        Assert.True(reader.Read());
        Assert.Equal("Max", reader.GetString(0));
    }
}