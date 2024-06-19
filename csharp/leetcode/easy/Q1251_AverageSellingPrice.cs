class Q1251_AverageSellingPrice : SqlQuestion
{
    public override string Query => 
    """
    select p.product_id, 
    COALESCE(
        round(sum(cast(price as float)*units)/sum(units), 2)
    , 0) as average_price
    from Prices p 
    left join UnitsSold u 
    on p.product_id = u.product_id 
    and purchase_date between start_date and end_date
    group by p.product_id
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
            ('2', '2019-02-21', '2019-03-31', '30'),
            ('3', '2019-02-21', '2019-03-31', '30');
            insert into UnitsSold (product_id, purchase_date, units)  values
            ('1', '2019-02-25', '100'),
            ('1', '2019-03-01', '15'),
            ('2', '2019-02-10', '200'),
            ('2', '2019-03-22', '30');
            """,
            new float[][]{[1, 6.96f], [2, 16.96f], [3, 0]}
        ],
        [
            """
            insert into Prices (product_id, start_date, end_date, price) values 
            ('1', '2019-01-18', '2019-01-22', '3'),
            ('1', '2019-01-23', '2019-01-25', '15'),
            ('2', '2019-01-21', '2019-01-29', '9'),
            ('2', '2019-01-30', '2019-02-04', '4');
            insert into UnitsSold (product_id, purchase_date, units)  values
            ('1', '2019-01-24', '3'),
            ('1', '2019-01-25', '4'),
            ('2', '2019-02-03', '2'),
            ('2', '2019-02-03', '5');            
            """,
            new float[][]{[1, 15f], [2, 4f]}
        ]
    ];
}
public class Q1251_AverageSellingPriceTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Prices (product_id int, start_date date, end_date date, price int);
    Create table If Not Exists UnitsSold (product_id int, purchase_date date, units int);
    """;

    [Theory(Skip = "Overwritten")]
    [InlineData("")]
    public override void OfficialTestCases(string testDataSql)
    {
        throw new NotImplementedException(testDataSql);
    }

    [Theory]
    [ClassData(typeof(Q1251_AverageSellingPriceTestData))]
    public void OfficialTestCases2(string testDataSql, float[][] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1251_AverageSellingPrice();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["product_id", "average_price"]);

        for(var i=0; i<expected.Length; i++)
        {
            Assert.True(reader.Read());
            Assert.Equal(expected[i][0], reader.GetInt32(0));
            Assert.Equal(Math.Round(expected[i][1] , 2), Math.Round(reader.GetFloat(1), 2));
        }
    }
}