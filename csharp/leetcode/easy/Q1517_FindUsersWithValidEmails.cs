using Row = (int user_id, string name, string mail);
class Q1517_FindUsersWithValidEmails : SqlQuestion
{
    public override string Query => 
    """
    select 1;
    """;
}
class Q1517_FindUsersWithValidEmailsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            """
            insert into Users (user_id, name, mail) values
            ('1', 'Winston', 'winston@leetcode.com'),
            ('2', 'Jonathan', 'jonathanisgreat'),
            ('3', 'Annabelle', 'bella-@leetcode.com'),
            ('4', 'Sally', 'sally.come@leetcode.com'),
            ('5', 'Marwan', 'quarz#2020@leetcode.com'),
            ('6', 'David', 'david69@gmail.com'),
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
        foreach(var row in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(row.user_id, reader.GetInt32(0));
            Assert.Equal(row.name, reader.GetString(1));
            Assert.Equal(row.mail, reader.GetString(2));
        }
    }
}