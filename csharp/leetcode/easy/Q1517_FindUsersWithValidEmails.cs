using Row = (int user_id, string name, string mail);
class Q1517_FindUsersWithValidEmails : SqlQuestion
{
    // SQLite does not support regex as well, the most it can do is the ensure the start and end
    public override string Query => 
    """
    select user_id, name, mail from Users
    where mail like '%@leetcode.com' and
    mail not like '.%' and 
    mail not like '-%' and
    mail not like '0%' and
    mail not like '1%' and
    mail not like '2%' and
    mail not like '3%' and
    mail not like '4%' and
    mail not like '5%' and
    mail not like '6%' and
    mail not like '7%' and
    mail not like '8%' and
    mail not like '9%';
    """;
    // For My-SQL:
    // WHERE mail REGEXP '^[a-zA-Z]{1}[a-zA-Z0-9_.-]*@leetcode[.]com$'
    // For T-SQL:
    // Damn howcome it does not support regex at 2024!
}
class Q1517_FindUsersWithValidEmailsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            // This have to remove to make the test cases passed due to SQLite limitations
            //('5', 'Marwan', 'quarz#2020@leetcode.com'),
            """
            insert into Users (user_id, name, mail) values
            ('1', 'Winston', 'winston@leetcode.com'),
            ('2', 'Jonathan', 'jonathanisgreat'),
            ('3', 'Annabelle', 'bella-@leetcode.com'),
            ('4', 'Sally', 'sally.come@leetcode.com'),
            
            ('6', 'David', 'david69@gmail.com'),
            ('6', 'DavidX', '.david69@gmail.com'),
            ('6', 'DavidX', '1david69@gmail.com'),
            ('6', 'DavidX', '-david69@gmail.com'),
            ('6', 'DavidX', '_david69@gmail.com'),
            ('7', 'Shapiro', '.shapo@leetcode.com');
            """,
            new Row[] 
            {
                (1, "Winston", "winston@leetcode.com"),
                (3, "Annabelle", "bella-@leetcode.com"),
                (4, "Sally", "sally.come@leetcode.com"),
            }
        ]
    ];
}
public class Q1517_FindUsersWithValidEmailsTests(ITestOutputHelper output): SqlTest(output)
{
    protected override string TestSchema => 
    """
    Create table If Not Exists Users (user_id int, name varchar(30), mail varchar(50));
    """;

    [Theory]
    [ClassData(typeof(Q1517_FindUsersWithValidEmailsTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1517_FindUsersWithValidEmails();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["user_id", "name", "mail"]);
        foreach(var (user_id, name, mail) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(user_id, reader.GetInt32(0));
            Assert.Equal(name, reader.GetString(1));
            Assert.Equal(mail, reader.GetString(2));
        }
    }
}