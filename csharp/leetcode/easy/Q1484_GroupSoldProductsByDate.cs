using Row = (string sell_date, int num_sold, string products);
class Q1484_GroupSoldProductsByDate : SqlQuestion
{
    public override string Query =>
    """
    select 1;
    """;
}
class Q1484_GroupSoldProductsByDateTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Activities (sell_date, product) values 
            ('2020-05-30', 'Headphone'),
            ('2020-06-01', 'Pencil'),
            ('2020-06-02', 'Mask'),
            ('2020-05-30', 'Basketball'),
            ('2020-06-01', 'Bible'),
            ('2020-06-02', 'Mask'),
            ('2020-05-30', 'T-Shirt');
            """
            , new Row[] {
                ("2020-05-30", 3, "Basketball,Headphone,T-Shirt"),
                ("2020-06-01", 2, "Bible,Pencil"),
                ("2020-06-02", 1, "Mask"),
            }
        ]
    ];
}
public class Q1484_GroupSoldProductsByDateTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Activities (sell_date date, product varchar(20));
    """;

    [Theory]
    [ClassData(typeof(Q1484_GroupSoldProductsByDateTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1484_GroupSoldProductsByDate();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["sell_date", "num_sold", "products"]);
        foreach(var (sell_date, num_sold, products) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(sell_date, reader.GetDateTime(0).ToString("yyyy-MM-dd"));
            Assert.Equal(num_sold, reader.GetInt32(1));
            Assert.Equal(products, reader.GetString(2));
        }
    }
}