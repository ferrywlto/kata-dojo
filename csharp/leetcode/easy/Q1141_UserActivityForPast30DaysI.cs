
class Q1141_UserActivityForPast30DaysI : SqlQuestion
{
    public override string Query => 
    """
    SELECT 1;
    """;
}
class Q1141_UserActivityForPast30DaysITestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            """
            insert into Activity (user_id, session_id, activity_date, activity_type) values 
            ('1', '1', '2019-07-20', 'open_session'),
            ('1', '1', '2019-07-20', 'scroll_down'),
            ('1', '1', '2019-07-20', 'end_session'),
            ('2', '4', '2019-07-20', 'open_session'),
            ('2', '4', '2019-07-21', 'send_message'),
            ('2', '4', '2019-07-21', 'end_session'),
            ('3', '2', '2019-07-21', 'open_session'),
            ('3', '2', '2019-07-21', 'send_message'),
            ('3', '2', '2019-07-21', 'end_session'),
            ('4', '3', '2019-06-25', 'open_session'),
            ('4', '3', '2019-06-25', 'end_session');     
            """
        ]
    ];
}
public class Q1141_UserActivityForPast30DaysITests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema => 
    """
    Create table If Not Exists Activity (user_id int, session_id int, activity_date date, activity_type varchar)
    """;
    [Theory]
    [ClassData(typeof(Q1141_UserActivityForPast30DaysITestData))]
    public override void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);

        var sut = new Q1141_UserActivityForPast30DaysI();
        var reader = ExecuteQuery(sut.Query, true);

        AssertResultSchema(reader, ["day", "active_users"]);

        Assert.True(reader.Read());
        Assert.Equal("2019-07-20", reader.GetString(0));
        Assert.Equal(2, reader.GetInt32(1));

        Assert.True(reader.Read());
        Assert.Equal("2019-07-21", reader.GetString(0));
        Assert.Equal(2, reader.GetInt32(1));
    }
}
