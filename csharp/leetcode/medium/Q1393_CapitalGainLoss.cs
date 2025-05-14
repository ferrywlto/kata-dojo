using Row = (string stock_name, int capital_gain_loss);
public class Q1393_CapitalGainLoss(ITestOutputHelper output) : SqlTest(output)
{
    public string Query =>
    """
    Select 1;
    """;
    public static TheoryData<string, Row[]> TestData => new()
    {
        {
            """
            insert into Stocks (stock_name, operation, operation_day, price) values 
            ('Leetcode', 'Buy', '1', '1000'),
            ('Corona Masks', 'Buy', '2', '10'),
            ('Leetcode', 'Sell', '5', '9000'),
            ('Handbags', 'Buy', '17', '30000'),
            ('Corona Masks', 'Sell', '3', '1010'),
            ('Corona Masks', 'Buy', '4', '1000'),
            ('Corona Masks', 'Sell', '5', '500'),
            ('Corona Masks', 'Buy', '6', '1000'),
            ('Handbags', 'Sell', '29', '7000'),
            ('Corona Masks', 'Sell', '10', '10000');
            """,
            new Row[]
            {
                 ("Corona Masks", 9500),
                 ("Leetcode", 8000),
                 ("Handbags", -23000),
            }
        }
    };
    protected override string TestSchema =>
    """
    Create Table If Not Exists Stocks (stock_name varchar(15), operation TEXT CHECK(operation IN ('Sell', 'Buy')), operation_day int, price int);
    """;
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var reader = ExecuteQuery(Query, true);
        AssertResultSchema(reader, ["stock_name", "capital_gain_loss"]);
        foreach (var (stock_name, capital_gain_loss) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(stock_name, reader.GetString(0));
            Assert.Equal(capital_gain_loss, reader.GetInt32(1));
        }
    }
}