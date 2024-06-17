class Q610_TriangleJudgement : SqlQuestion
{
    public override string Query =>
    """
    SELECT x, y, z,
        CASE
            WHEN (x+y > z) 
            AND (x+z > y)
            AND (y+z > x)
            THEN 'Yes' ELSE 'No' 
        END as triangle
    FROM Triangle
    """;
}

class Q610_TriangleJudgementTestData : TestData
{
    protected override List<object[]> Data =>
    [[
        """
        INSERT INTO Triangle VALUES
        (13,15,30),
        (10,20,15);
        """
    ]];
}
[Trait("QuestionType", "SQL")]
public class Q610_TriangleJudgementTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Triangle (x INT, y INT, z INT);
    """;

    [Theory]
    [ClassData(typeof(Q610_TriangleJudgementTestData))]
    public override void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);

        var sut = new Q610_TriangleJudgement();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["x", "y", "z", "triangle"]);

        Assert.True(reader.Read());
        Assert.Equal("No", reader.GetString(3));

        Assert.True(reader.Read());
        Assert.Equal("Yes", reader.GetString(3));

        Assert.False(reader.Read());
    }
}