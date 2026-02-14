class Q620_NotBoringMovies : SqlQuestion
{
    public override string Query =>
    """
    SELECT *
    FROM Cinema
    WHERE description <> 'boring'
    AND id % 2 = 1
    ORDER BY rating DESC;
    """;
}

class Q620_NotBoringMoviesTestData : TestData
{
    protected override List<object[]> Data =>
    [[
        """
        INSERT INTO Cinema VALUES
        (1, 'War', 'great 3D', 8.9),
        (2, 'Science', 'fiction', 8.5),
        (3, 'irish', 'boring', 6.2),
        (4, 'Ice song', 'Fantacy', 8.6),
        (5, 'House card', 'Interesting', 9.1);
        """
    ]];
}
[Trait("QuestionType", "SQL")]
public class Q620_NotBoringMoviesTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Cinema (id INT, movie VARCHAR, description VARCHAR, rating FLOAT);
    """;

    [Theory]
    [ClassData(typeof(Q620_NotBoringMoviesTestData))]
    public void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);

        var sut = new Q620_NotBoringMovies();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["id", "movie", "description", "rating"]);

        Assert.True(reader.Read());
        Assert.Equal(5, reader.GetInt32(0));
        Assert.Equal("House card", reader.GetString(1));
        Assert.Equal("Interesting", reader.GetString(2));
        Assert.Equal(Math.Round(9.1, 2), Math.Round(reader.GetFloat(3), 2));

        Assert.True(reader.Read());
        Assert.Equal(1, reader.GetInt32(0));
        Assert.Equal("War", reader.GetString(1));
        Assert.Equal("great 3D", reader.GetString(2));
        Assert.Equal(Math.Round(8.9, 2), Math.Round(reader.GetFloat(3), 2));

        Assert.False(reader.Read());
    }
}
