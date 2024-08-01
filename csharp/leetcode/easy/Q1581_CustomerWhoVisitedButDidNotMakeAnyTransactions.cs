using Row = (int customer_id, int count_no_trans);
class Q1581_CustomerWhoVisitedButDidNotMakeAnyTransactions : SqlQuestion
{
    public override string Query =>
    """
    select customer_id, count(customer_id) as 'count_no_trans' from
    (
        select customer_id, v.visit_id, transaction_id
        from Visits v
        left join Transactions t
        on v.visit_id = t.visit_id
        where transaction_id is null
    ) temp group by customer_id
    order by count_no_trans desc, customer_id asc
    ;
    """;
}
class Q1581_CustomerWhoVisitedButDidNotMakeAnyTransactionsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            """
            insert into Visits (visit_id, customer_id) values 
            ('1', '23'),
            ('2', '9'),
            ('4', '30'),
            ('5', '54'),
            ('6', '96'),
            ('7', '54'),
            ('8', '54');

            insert into Transactions (transaction_id, visit_id, amount) values 
            ('2', '5', '310'),
            ('3', '5', '300'),
            ('9', '5', '200'),
            ('12', '1', '910'),
            ('13', '2', '970');
            """,
            new Row[] 
            {
                (54, 2),
                (30, 1),
                (96, 1),
            }
        ]
    ];
}
public class Q1581_CustomerWhoVisitedButDidNotMakeAnyTransactionsTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema => 
    """
    Create table If Not Exists Visits(visit_id int, customer_id int);
    Create table If Not Exists Transactions(transaction_id int, visit_id int, amount int);
    """;

    [Theory]
    [ClassData(typeof(Q1581_CustomerWhoVisitedButDidNotMakeAnyTransactionsTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1581_CustomerWhoVisitedButDidNotMakeAnyTransactions();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["customer_id", "count_no_trans"]);
        foreach((int customer_id, int count_no_trans) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(customer_id, reader.GetInt32(0));
            Assert.Equal(count_no_trans, reader.GetInt32(1));
        }
    }
}