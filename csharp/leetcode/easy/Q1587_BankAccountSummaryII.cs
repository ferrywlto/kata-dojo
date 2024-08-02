using Row = (string name, int balance);
class Q1587_BankAccountSummaryII : SqlQuestion
{
    public override string Query => 
    """
    select 1;
    """;
}
class Q1587_BankAccountSummaryIITestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            """
            insert into Users (account, name) values 
            ('900001', 'Alice'),
            ('900002', 'Bob'),
            ('900003', 'Charlie');

            insert into Transactions (trans_id, account, amount, transacted_on) values 
            ('1', '900001', '7000', '2020-08-01'),
            ('2', '900001', '7000', '2020-09-01'),
            ('3', '900001', '-3000', '2020-09-02'),
            ('4', '900002', '1000', '2020-09-12'),
            ('5', '900003', '6000', '2020-08-07'),
            ('6', '900003', '6000', '2020-09-07'),
            ('7', '900003', '-4000', '2020-09-11');
            """,
            new Row[] { ("Alice", 11000) }
        ]
    ];
}
public class Q1587_BankAccountSummaryIITests(ITestOutputHelper output):SqlTest(output)
{
    protected override string TestSchema => 
    """
    Create table If Not Exists Users (account int, name varchar(20));
    Create table If Not Exists Transactions (trans_id int, account int, amount int, transacted_on date);
    """;

    [Theory]
    [ClassData(typeof(Q1587_BankAccountSummaryIITestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1587_BankAccountSummaryII();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["name", "balance"]);
        foreach((var name, var balance) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(name, reader.GetString(0));
            Assert.Equal(balance, reader.GetInt32(1));
        }
    }
}