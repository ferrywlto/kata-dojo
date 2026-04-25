using Row = (int user_id, string email);
public class Q3436_FindValidEmails(ITestOutputHelper output) : SqlTest(output)

{
    // MSSQL
    // public string Query => 
    // """
    // Select user_id, email
    // from Users
    // where email like '%@%'
    // and email like '%.com'
    // and SUBSTRING(email, 1, CHARINDEX('@', email) - 1) not like '%[^A-Za-z0-9_]%'
    // and SUBSTRING(
    //     email, 
    //     CHARINDEX('@', email) + 1, 
    //     CHARINDEX('.com', email) - CHARINDEX('@', email) - 1
    // ) NOT LIKE '%[^A-Za-z]%'
    // order by user_id;
    // """;
    public string Query =>
    """
    Select user_id, email
    from Users
    where email like '%@%'
    and email like '%.com'
    and substr(email, 1, instr(email, '@') - 1) NOT GLOB '*[^A-Za-z0-9_]*'
    and substr(
            email,
            instr(email, '@') + 1,
            instr(email, '.com') - instr(email, '@') - 1
    ) NOT GLOB '*[^A-Za-z]*'
    order by user_id;
    """;
    public static TheoryData<string, Row[]> TestData => new()
    {
        {
            """
            insert into Users (user_id, email) values 
            ('1', 'alice@example.com'),
            ('2', 'bob_at_example.com'),
            ('3', 'charlie@example.net'),
            ('4', 'david@domain.com'),
            ('5', 'eve@invalid');
            """,
            new Row[]
            {
                (1, "alice@example.com"),
                (4, "david@domain.com"),
            }
        }
    };

    protected override string TestSchema =>
    """
    CREATE TABLE If not Exists Users (
        user_id INT,
        email VARCHAR(255)
    );
    """;

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var reader = ExecuteQuery(Query, true);
        AssertResultSchema(reader, ["user_id", "email"]);
        foreach (var (user_id, email) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(user_id, reader.GetInt32(0));
            Assert.Equal(email, reader.GetString(1));
        }
    }
}
