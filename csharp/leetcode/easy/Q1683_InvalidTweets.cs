class Q1683_InvalidTweets : SqlQuestion
{
    public override string Query =>
    """
    select tweet_id from Tweets
    where length(content) > 15;
    """;
}
class Q1683_InvalidTweetsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Tweets (tweet_id, content) values ('1', 'Vote for Biden');
            insert into Tweets (tweet_id, content) values ('2', 'Let us make America great again!');
            """, 2
        ]
    ];
}
public class Q1683_InvalidTweetsTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Tweets(tweet_id int, content varchar(50));
    """;

    [Theory]
    [ClassData(typeof(Q1683_InvalidTweetsTestData))]
    public void OfficialTestCases(string testDataSql, int expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1683_InvalidTweets();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["tweet_id"]);
        Assert.True(reader.Read());
        Assert.Equal(expected, reader.GetInt32(0));
    }
}
