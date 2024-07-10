using Row = (string name, int travelled_distance);
class Q1407_TopTravellers : SqlQuestion
{
    public override string Query =>
    """
    select name, coalesce(travelled_distance,0) as travelled_distance from 
    Users u left join 
    (
        select user_id, sum(distance) as travelled_distance 
        from Rides
        group by user_id
    ) r
    on u.id = r.user_id
    order by travelled_distance desc, name asc
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
            """,
            new Row[] {
                ("Elvis", 450),
                ("Lee", 450),
                ("Bob", 317),
                ("Jonathan", 312),
                ("Alex", 222),
                ("Alice", 120),
                ("Donald", 0),
            }
        ]
    ];
}
public class Q1407_TopTravellersTests: SqlTest
{
    protected override string TestSchema => 
    """
    Create Table If Not Exists Users (id int, name varchar(30));
    Create Table If Not Exists Rides (id int, user_id int, distance int);
    """;

    [Theory]
    [ClassData(typeof(Q1407_TopTravellersTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1407_TopTravellers();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["name", "travelled_distance"]);
        foreach(var (name, travelled_distance) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(name, reader.GetString(0));
            Assert.Equal(travelled_distance, reader.GetInt32(1));
        }
    }
}