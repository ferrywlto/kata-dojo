
class Q1050_ActorsAndDirectorsWhoCooperatedAtLeastThreeTimes : SqlQuestion
{
    public override string Query => 
    """
    SELECT actor_id, director_id FROM ActorDirector
    GROUP BY actor_id, director_id
    HAVING count(*) >= 3
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
        ],
    ];
}
[Trait("QuestionType", "SQL")]
public class Q1050_ActorsAndDirectorsWhoCooperatedAtLeastThreeTimesTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS ActorDirector(actor_id int, director_id int, timestamp int);
    """;

    [Theory]
    [ClassData(typeof(Q1050_ActorsAndDirectorsWhoCooperatedAtLeastThreeTimesTestData))]
    public void OfficialTestCases(string input)
    {
        ArrangeTestData(input);

        var sut = new Q1050_ActorsAndDirectorsWhoCooperatedAtLeastThreeTimes();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["actor_id", "director_id"]);

        Assert.True(reader.Read());
        Assert.Equal(1, reader.GetInt32(0));
        Assert.Equal(1, reader.GetInt32(1));
    }
}
