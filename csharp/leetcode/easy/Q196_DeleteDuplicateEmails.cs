class Q196_DeleteDuplicateEmails : SqlQuestion
{
    public override string Query =>
    """
    DELETE FROM Person 
    WHERE id IN
    (
        SELECT p1.id 
        FROM Person p1, Person p2 
        WHERE p1.email = p2.email 
        AND p1.id > p2.id
    );
    """;
}

class Q196_DeleteDuplicateEmailsTestData : TestData
{
    protected override List<object[]> Data =>
    [[
        """
        INSERT INTO Person VALUES
        (1, 'john@example.com'),
        (2, 'bob@example.com'),
        (3, 'john@example.com');
        """
    ]];
}
[Trait("QuestionType", "SQL")]
public class Q196_DeleteDuplicateEmailsTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Person (id INT, email VARCHAR)
    """;

    [Theory]
    [ClassData(typeof(Q196_DeleteDuplicateEmailsTestData))]
    public void OfficialTestCases(string input)
    {
        ArrangeTestData(input);

        var sut = new Q196_DeleteDuplicateEmails();
        var deleteCount = ExecuteCommand(sut.Query);
        Assert.Equal(1, deleteCount);

        var reader = ExecuteQuery("SELECT * FROM Person;");
        AssertResultSchema(reader, ["id", "email"]);
        
        Assert.True(reader.Read());
        Assert.Equal(1, reader.GetInt32(0));
        Assert.Equal("john@example.com", reader.GetString(1));

        Assert.True(reader.Read());
        Assert.Equal(2, reader.GetInt32(0));
        Assert.Equal("bob@example.com", reader.GetString(1));
    }
}