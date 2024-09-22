using Row = (int contest_id, float percentage);
class Q1633_PercentageOfUsersAttendedContest : SqlQuestion
{
    public override string Query =>
    """
    select contest_id, 
    round((cast(count(user_id) as float) / (select cast(count(user_id) as float) from Users)) * 100, 2) 
    as 'percentage' from Register
    group by contest_id
    order by percentage desc, contest_id;
    
    """;
}
class Q1633_PercentageOfUsersAttendedContestTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Users (user_id, user_name) values 
            ('6', 'Alice'),
            ('2', 'Bob'),
            ('7', 'Alex');

            insert into Register (contest_id, user_id) values 
            ('215', '6'),
            ('209', '2'),
            ('208', '2'),
            ('210', '6'),
            ('208', '6'),
            ('209', '7'),
            ('209', '6'),
            ('215', '7'),
            ('208', '7'),
            ('210', '2'),
            ('207', '2'),
            ('210', '7');                        
            """,
            new Row[]
            {
                (208, 100.0f),
                (209, 100.0f),
                (210, 100.0f),
                (215, 66.67f),
                (207, 33.33f),
            }
        ]
    ];
}
public class Q1633_PercentageOfUsersAttendedContestTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Users (user_id int, user_name varchar(20));
    Create table If Not Exists Register (contest_id int, user_id int);
    """;

    [Theory]
    [ClassData(typeof(Q1633_PercentageOfUsersAttendedContestTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1633_PercentageOfUsersAttendedContest();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["contest_id", "percentage"]);
        foreach ((var contest_id, var percentage) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(contest_id, reader.GetInt32(0));
            Assert.Equal(Math.Round(percentage, 2), Math.Round(reader.GetDouble(1), 2));
        }
    }
}