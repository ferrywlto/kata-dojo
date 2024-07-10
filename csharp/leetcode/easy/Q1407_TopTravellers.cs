
class Q1407_TopTravellers : SqlQuestion
{
    public override string Query =>
    """
    select 1;
    """;
}
class Q1407_TopTravellersTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            """
            insert into Users (id, name) values
            ('1', 'Alice'),
            ('2', 'Bob'),
            ('3', 'Alex'),
            ('4', 'Donald'),
            ('7', 'Lee'),
            ('13', 'Jonathan'),
            ('19', 'Elvis');
            
            insert into Rides (id, user_id, distance) values
            ('1', '1', '120'),
            ('2', '2', '317'),
            ('3', '3', '222'),
            ('4', '7', '100'),
            ('5', '13', '312'),
            ('6', '19', '50'),
            ('7', '7', '120'),
            ('8', '19', '400'),
            ('9', '7', '230');
            """
        ]
    ];
}
public class Q1407_TopTravellersTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema => 
    """
    Create Table If Not Exists Users (id int, name varchar(30));
    Create Table If Not Exists Rides (id int, user_id int, distance int);
    """;

    [Theory]
    [ClassData(typeof(Q1407_TopTravellersTestData))]
    public void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1407_TopTravellers();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["name", "travelled_distance"]);
    }
}