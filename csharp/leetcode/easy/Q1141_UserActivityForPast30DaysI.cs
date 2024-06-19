
class Q1141_UserActivityForPast30DaysI : SqlQuestion
{
    public override string Query => 
    """
    SELECT activity_date as day, count(user_id) as active_users 
    FROM 
        (
            select distinct user_id, activity_date from Activity
            WHERE activity_date <= '2019-07-27'
            AND activity_date > date('2019-07-27', '-30 days')
        )
    GROUP BY activity_date;
    """;
    /* T-SQL
    """
    SELECT activity_date as day, count(user_id) as active_users 
    FROM 
        (
            SELECT DISTINCT user_id, activity_date 
            FROM Activity
            WHERE activity_date <= '2019-07-27'
            AND activity_date > DATEADD(day, -30, '2019-07-27')
        ) AS subquery
    GROUP BY activity_date;
    """
    */
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
    public void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);

        var sut = new Q1141_UserActivityForPast30DaysI();
        var reader = ExecuteQuery(sut.Query);

        AssertResultSchema(reader, ["day", "active_users"]);

        Assert.True(reader.Read());
        Assert.Equal("2019-07-20", reader.GetString(0));
        Assert.Equal(2, reader.GetInt32(1));

        Assert.True(reader.Read());
        Assert.Equal("2019-07-21", reader.GetString(0));
        Assert.Equal(2, reader.GetInt32(1));
    }
}
