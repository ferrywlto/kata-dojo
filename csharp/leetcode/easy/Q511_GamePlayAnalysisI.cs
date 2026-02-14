using System.Data;
using Microsoft.Data.Sqlite;

class Q511_GamePlayAnalysis1 : SqlQuestion
{
    public override string Query =>
    """
    SELECT player_id, MIN(event_date) as min_date
    FROM Activity
    GROUP BY player_id;
    """;
}

class Q511_GamePlayAnalysis1TestData : TestData
{
    protected override List<object[]> Data =>
    [[
        """
        INSERT INTO Activity VALUES 
        ('1', '2', '2016-03-01', 5),
        ('1', '2', '2016-05-02', 6),
        ('2', '3', '2017-06-25', 1),
        ('3', '1', '2016-03-02', 0),
        ('3', '4', '2016-03-02', 5);
        """
    ]];
}
[Trait("QuestionType", "SQL")]
public class Q511_GamePlayAnalysis1Tests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Activity (player_id INT, device_id INT, event_date DATE, games_played INT);
    """;

    [Theory]
    [ClassData(typeof(Q511_GamePlayAnalysis1TestData))]
    public void OfficialTestCases(string input)
    {
        ArrangeTestData(input);

        var sut = new Q511_GamePlayAnalysis1();

        var reader = ExecuteQuery(sut.Query);

        AssertResultSchema(reader, ["player_id", "min_date"]);
        AssertRow(reader, 1, new DateTime(2016, 3, 1));
        AssertRow(reader, 2, new DateTime(2017, 6, 25));
        AssertRow(reader, 3, new DateTime(2016, 3, 2));
    }

    private void AssertRow(IDataReader reader, int playerId, DateTime firstLogin)
    {
        Assert.True(reader.Read());
        Assert.Equal(playerId, reader.GetInt32(0));
        Assert.Equal(firstLogin, reader.GetDateTime(1));
    }
}
