class Q1148_ArticleViewsI : SqlQuestion
{
    public override string Query => 
    """
    select distinct viewer_id as id
    from Views
    where author_id = viewer_id
    order by id asc;
    """;
}
class Q1148_ArticleViewsITestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            """
            insert into Views (article_id, author_id, viewer_id, view_date) values 
            ('1', '3', '5', '2019-08-01'),
            ('1', '3', '6', '2019-08-02'),
            ('2', '7', '7', '2019-08-01'),
            ('2', '7', '6', '2019-08-02'),
            ('4', '7', '1', '2019-07-22'),
            ('3', '4', '4', '2019-07-21'),
            ('3', '4', '4', '2019-07-21');
            """
        ]
    ];
}
public class Q1148_ArticleViewsITests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema => 
    """
    Create table If Not Exists Views (article_id int, author_id int, viewer_id int, view_date date);
    """;

    [Theory]
    [ClassData(typeof(Q1148_ArticleViewsITestData))]
    public override void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1148_ArticleViewsI();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["id"]);

        Assert.True(reader.Read());
        Assert.Equal(4, reader.GetInt32(0));

        Assert.True(reader.Read());
        Assert.Equal(7, reader.GetInt32(0));
    }
}