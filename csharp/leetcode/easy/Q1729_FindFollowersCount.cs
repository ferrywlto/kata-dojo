using Row = (int user_id, int followers_count);
class Q1729_FindFollowersCount : SqlQuestion
{
    public override string Query =>
    """
    select 1;
    """;
}
class Q1729_FindFollowersCountTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Followers (user_id, follower_id) values
             ('0', '1'),
             ('1', '0'),
             ('2', '0'),
             ('2', '1');
            """,
            new Row[] 
            {
                (0,1),
                (1,1),
                (2,2),
            }
        ]
    ];
}
public class Q1729_FindFollowersCountTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema => 
    """
    Create table If Not Exists Followers(user_id int, follower_id int)
    """;

    [Theory]
    [ClassData(typeof(Q1729_FindFollowersCountTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1729_FindFollowersCount();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["user_id", "followers_count"]);
        foreach((var user_id, var followers_count) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(user_id, reader.GetInt32(0));
            Assert.Equal(followers_count, reader.GetInt32(1));
        }
    }
}