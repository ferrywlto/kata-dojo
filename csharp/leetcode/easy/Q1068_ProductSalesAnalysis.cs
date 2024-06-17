
class Q1068_ProductSalesAnalysis : SqlQuestion
{
    // The T-SQL test cases on leetcode is broken, it still timeout as most other developers encountered.
    // Not even success after manually applying index.
    // The same SQL passes all test cases for MySQL 
    public override string Query =>
    """
    SELECT p.product_name, s.year, s.price
    FROM Sales s left join Product p
    ON s.product_id = p.product_id;
    """;
}
class Q1068_ProductSalesAnalysisTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
        """
        insert into Sales values 
        (1, 100, 2008, 10, 5000),
        (2, 100, 2009, 12, 5000),
        (7, 200, 2011, 15, 9000);
        
        insert into Product values 
        (100, 'Nokia'),
        (200, 'Apple'),
        (300, 'Samsung');
        """,
        ]
    ];
}
[Trait("QuestionType", "SQL")]
public class Q1068_ProductSalesAnalysisTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    create table if not exists Sales(sale_id int, product_id int, year int, quantity int, price int);
    create table if not exists Product(product_id int, product_name varchar)
    """;

    [Theory]
    [ClassData(typeof(Q1068_ProductSalesAnalysisTestData))]
    public override void OfficialTestCases(string input)
    {
        ArrangeTestData(input);

        var sut = new Q1068_ProductSalesAnalysis();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["product_name", "year", "price"]);

        Assert.True(reader.Read());
        Assert.Equal("Nokia", reader.GetString(0));
        Assert.Equal(2008, reader.GetInt32(1));
        Assert.Equal(5000, reader.GetInt32(2));

        Assert.True(reader.Read());
        Assert.Equal("Nokia", reader.GetString(0));
        Assert.Equal(2009, reader.GetInt32(1));
        Assert.Equal(5000, reader.GetInt32(2));

        Assert.True(reader.Read());
        Assert.Equal("Apple", reader.GetString(0));
        Assert.Equal(2011, reader.GetInt32(1));
        Assert.Equal(9000, reader.GetInt32(2));
    }
}
