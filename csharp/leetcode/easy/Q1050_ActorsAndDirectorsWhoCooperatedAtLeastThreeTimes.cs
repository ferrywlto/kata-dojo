
class Q1050_ActorsAndDirectorsWhoCooperatedAtLeastThreeTimes : SqlQuestion
{
    public override string Query => 
    """
    SELECT 1;
    """;
}
class Q1050_ActorsAndDirectorsWhoCooperatedAtLeastThreeTimesTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            """
            INSERT INTO ActorDirector VALUES
            (1,1,0),
            (1,1,1),
            (1,1,2),
            (1,2,3),
            (1,2,4),
            (2,1,5),
            (2,1,6);
            """
        ]
    ];
}
public class Q1050_ActorsAndDirectorsWhoCooperatedAtLeastThreeTimesTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS ActorDirector(actor_id int, director_id int, timestamp int);
    """;

    [Theory]
    [ClassData(typeof(Q1050_ActorsAndDirectorsWhoCooperatedAtLeastThreeTimesTestData))]
    public override void OfficialTestCases(string input)
    {
        ArrangeTestData(input);

        var sut = new Q1050_ActorsAndDirectorsWhoCooperatedAtLeastThreeTimes();
        var reader = ExecuteQuery(sut.Query);

        DebugReader(reader);

        Assert.True(reader.HasRows);
        Assert.Equal(2, reader.FieldCount);
        Assert.Equal("actor_id", reader.GetName(0));
        Assert.Equal("director_id", reader.GetName(1));

        Assert.True(reader.Read());
        Assert.Equal(1, reader.GetInt32(0));
        Assert.Equal(1, reader.GetInt32(1));
    }
}
