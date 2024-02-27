namespace dojo.leetcode;

public class Q196_DeleteDuplicateEmailsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            INSERT INTO Person VALUES (1, 'john@example.com');
            INSERT INTO Person VALUES (2, 'bob@example.com');
            INSERT INTO Person VALUES (3, 'john@example.com');
            """
        ]
    ];
}

public class Q196_DeleteDuplicateEmailsTests(ITestOutputHelper output) : DatabaseTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Person (id INT, email VARCHAR(255))
    """;

    [Theory]
    [ClassData(typeof(Q196_DeleteDuplicateEmailsTestData))]
    public override void OfficialTestCases(string input)
    {
        InputTestData(input);

        var sut = new Q196_DeleteDuplicateEmails();
        var deleteCount = ExecuteCommand(sut.Query);
        Assert.Equal(1, deleteCount);

        var result = ExecuteQuery("SELECT * FROM Person;");

        Assert.True(result.Read());
        Assert.Equal(1, result.GetInt32(0));
        Assert.Equal("john@example.com", result.GetString(1));

        Assert.True(result.Read());
        Assert.Equal(2, result.GetInt32(0));
        Assert.Equal("bob@example.com", result.GetString(1));
    }
}

public class Q196_DeleteDuplicateEmails: SqlQuestion
{
    public override string Query =>
    """
    DELETE FROM Person WHERE id IN
     (SELECT p1.id FROM Person p1, Person p2 WHERE p1.email = p2.email AND p1.id > p2.id)
    """;
}