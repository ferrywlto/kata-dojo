class Q607_SalesPerson : SqlQuestion
{
    public override string Query => 
    """
    SELECT s.name
    FROM SalesPerson s
    WHERE NOT EXISTS (
        SELECT 1 
        FROM Orders o 
        JOIN Company c 
        ON o.com_id = c.com_id 
        WHERE o.sales_id = s.sales_id 
        AND c.name = 'RED'
    );    
    """;
}

class Q607_SalesPersonTestData : TestData
{
    protected override List<object[]> Data => 
    [[
        """
        INSERT INTO SalesPerson VALUES
        (1, 'John', 100000, 6, '4/1/2006'),
        (2, 'Amy', 12000, 5, '5/1/2010'),
        (3, 'Mark', 65000, 12, '12/25/2008'),
        (4, 'Pam', 25000, 25, '1/1/2005'),
        (5, 'Alex', 5000, 10, '2/3/2007');

        INSERT INTO Company VALUES
        (1, 'RED', 'Boston'),
        (2, 'ORANGE', 'New York'),
        (3, 'YELLOW', 'Boston'),
        (4, 'GREEN', 'Austin');

        INSERT INTO Orders VALUES
        (1, '1/1/2014', 3, 4, 10000),
        (2, '2/1/2014', 4, 5, 5000),
        (3, '3/1/2014', 1, 1, 50000),
        (4, '4/1/2014', 1, 4, 25000);
        """
    ]];
}
[Trait("QuestionType", "SQL")]
public class Q607_SalesPersonTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema => 
    """
    CREATE TABLE IF NOT EXISTS SalesPerson (sales_id INT, name VARCHAR, salary INT, commission_rate INT, hire_date DATE);
    CREATE TABLE IF NOT EXISTS Company (com_id INT, name VARCHAR, city VARCHAR);
    CREATE TABLE IF NOT EXISTS Orders (order_id INT, order_date DATE, com_ID INT, sales_id INT, amount INT);
    """;

    [Theory]
    [ClassData(typeof(Q607_SalesPersonTestData))]
    public override void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);

        var sut = new Q607_SalesPerson();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["name"]);

        Assert.True(reader.Read());
        Assert.Equal("Amy", reader.GetString(0));

        Assert.True(reader.Read());
        Assert.Equal("Mark", reader.GetString(0));

        Assert.True(reader.Read());
        Assert.Equal("Alex", reader.GetString(0));
    }
}