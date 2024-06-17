
class Q1211_QueriesQualityAndPercentage : SqlQuestion
{
    public override string Query => 
    """
    select 1;
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
            ('Cat', 'Sphynx', '7', '4');           
            """
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
    public override void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1211_QueriesQualityAndPercentage();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["query_name", "quality", "poor_query_percentage"]);

        Assert.True(reader.Read());
        Assert.Equal("Dog", reader.GetString(0));
        Assert.Equal(2.50, reader.GetFloat(1));
        Assert.Equal(33.33 , reader.GetFloat(2));

        Assert.True(reader.Read());
        Assert.Equal("Cat", reader.GetString(0));
        Assert.Equal(0.66, reader.GetFloat(1));
        Assert.Equal(33.33 , reader.GetFloat(2));
    }
}
