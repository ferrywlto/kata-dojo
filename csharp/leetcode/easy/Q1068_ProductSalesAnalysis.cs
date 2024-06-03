
class Q1068_ProductSalesAnalysis : SqlQuestion
{
    public override string Query =>
    """
    SELECT 1;
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
        var reader = ExecuteQuery(sut.Query, true);

        Assert.True(reader.HasRows);
        Assert.Equal(3, reader.FieldCount);
        Assert.Equal("product_name", reader.GetName(0));
        Assert.Equal("year", reader.GetName(1));
        Assert.Equal("price", reader.GetName(2));

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
