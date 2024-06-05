class Q584_FindCustomerReferee : SqlQuestion
{
    public override string Query =>
    """
    SELECT name 
    FROM Customer 
    WHERE referee_id IS NULL 
    OR referee_id IS NOT 2;
    """;
}

class Q584_FindCustomerRefereeTestData : TestData
{
    protected override List<object[]> Data =>
    [[
        """
        INSERT INTO Customer VALUES
        (1, 'Will', null),
        (2, 'Jane', null),
        (3, 'Alex', 2),
        (4, 'Bill', null),
        (5, 'Zack', 1),
        (6, 'Mark', 2);
        """
    ]];
}
[Trait("QuestionType", "SQL")]
public class Q584_FindCustomerRefereeTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Customer (id INT, name VARCHAR, referee_id INT); 
    """;

    [Theory]
    [ClassData(typeof(Q584_FindCustomerRefereeTestData))]
    public override void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);

        var sut = new Q584_FindCustomerReferee();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["name"]);

        Assert.True(reader.Read());
        Assert.Equal("Will", reader.GetString(0));

        Assert.True(reader.Read());
        Assert.Equal("Jane", reader.GetString(0));

        Assert.True(reader.Read());
        Assert.Equal("Bill", reader.GetString(0));

        Assert.True(reader.Read());
        Assert.Equal("Zack", reader.GetString(0));
    }
}