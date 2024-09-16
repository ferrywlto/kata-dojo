using Row = (int user_id, string last_stamp);
class Q1890_TheLatestLoginIn2020 : SqlQuestion
{
    public override string Query =>
    """
    select 1;
    """;
}
class Q1890_TheLatestLoginIn2020TestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Logins (user_id, time_stamp) values
            ('6', '2020-06-30 15:06:07'),
            ('6', '2021-04-21 14:06:06'),
            ('6', '2019-03-07 00:18:15'),
            ('8', '2020-02-01 05:10:53'),
            ('8', '2020-12-30 00:46:50'),
            ('2', '2020-01-16 02:49:50'),
            ('2', '2019-08-25 07:59:08'),
            ('14', '2019-07-14 09:00:00'),
            ('14', '2021-01-06 11:59:59');
            """,
            new Row[]
            {
                (6, "2020-06-30 15:06:07"),
                (8, "2020-12-30 00:46:50"),
                (2, "2020-01-16 02:49:50"),
            }
        ]
    ];
}
public class Q1890_TheLatestLoginIn2020Tests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Logins (user_id int, time_stamp datetime);
    """;

    [Theory]
    [ClassData(typeof(Q1890_TheLatestLoginIn2020TestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1890_TheLatestLoginIn2020();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["user_id", "last_stamp"]);
        foreach ((var user_id, var last_stamp) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(user_id, reader.GetInt32(0));
            Assert.Equal(last_stamp, reader.GetString(1));
        }
    }
}