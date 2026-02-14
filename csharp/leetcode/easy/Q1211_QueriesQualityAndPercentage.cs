class Q1211_QueriesQualityAndPercentage : SqlQuestion
{
    public override string Query =>
    """
    select q1.query_name as query_name, quality,
    case 
        when good_count = 0 then 0 
    else 
        round(cast(coalesce(poor_count, 0) as float)/good_count*100, 2) 
    end as poor_query_percentage
    from
    (
        select query_name, 
        round(sum(cast (rating as float)/position)/count(query_name), 2) as quality,
        count(query_name) as good_count
        from Queries
        where query_name is not null
        group by query_name
    ) q1 left join 
    (
        select query_name, count(query_name) as poor_count 
        from Queries
        where rating < 3
        group by query_name
    ) q2 on q1.query_name = q2.query_name
    order by query_name desc;   
    """;
}
class Q1211_QueriesQualityAndPercentageTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Queries (query_name, result, position, rating) values 
            ('Dog', 'Golden Retriever', '1', '5'),
            ('Dog', 'German Shepherd', '2', '5'),
            ('Dog', 'Mule', '200', '1'),
            ('Cat', 'Shirazi', '5', '2'),
            ('Cat', 'Siamese', '3', '3'),
            ('Cat', 'Sphynx', '7', '4'),
            (NULL, 'Sphynx', '7', '4');         
            """
            // The NULL is to test if division by zero encountered
        ]
    ];
}
public class Q1211_QueriesQualityAndPercentageTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Queries (query_name varchar(30), result varchar(50), position int, rating int);
    """;

    [Theory]
    [ClassData(typeof(Q1211_QueriesQualityAndPercentageTestData))]
    public void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1211_QueriesQualityAndPercentage();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["query_name", "quality", "poor_query_percentage"]);

        Assert.True(reader.Read());
        Assert.Equal("Dog", reader.GetString(0));
        Assert.Equal(2.50, Math.Round(reader.GetFloat(1), 2));
        Assert.Equal(33.33, Math.Round(reader.GetFloat(2), 2));

        Assert.True(reader.Read());
        Assert.Equal("Cat", reader.GetString(0));
        Assert.Equal(0.66, Math.Round(reader.GetFloat(1), 2));
        Assert.Equal(33.33, Math.Round(reader.GetFloat(2), 2));
    }
}
