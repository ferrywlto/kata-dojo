class Q1251_AverageSellingPrice : SqlQuestion
{
    public override string Query => 
    """
    select 1;
    """;
}
class Q1251_AverageSellingPriceTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            """
            insert into Prices (product_id, start_date, end_date, price) values 
            ('1', '2019-02-17', '2019-02-28', '5'),
            ('1', '2019-03-01', '2019-03-22', '20'),
            ('2', '2019-02-01', '2019-02-20', '15'),
            ('2', '2019-02-21', '2019-03-31', '30');
            insert into UnitsSold (product_id, purchase_date, units)  values
            ('1', '2019-02-25', '100'),
            ('1', '2019-03-01', '15'),
            ('2', '2019-02-10', '200'),
            ('2', '2019-03-22', '30');
            """
        ]
    ];
}
public class Q1251_AverageSellingPriceTests : SqlTest
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Prices (product_id int, start_date date, end_date date, price int);
    Create table If Not Exists UnitsSold (product_id int, purchase_date date, units int);
    """;

    [Theory]
    [ClassData(typeof(Q1251_AverageSellingPriceTestData))]
    public override void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1251_AverageSellingPrice();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["product_id", "average_price"]);

        Assert.True(reader.Read());
        Assert.Equal(1, reader.GetInt32(0));
        Assert.Equal(6.96, reader.GetFloat(1));        
        
        Assert.True(reader.Read());
        Assert.Equal(2, reader.GetInt32(0));
        Assert.Equal(16.96, reader.GetFloat(1));
    }
}