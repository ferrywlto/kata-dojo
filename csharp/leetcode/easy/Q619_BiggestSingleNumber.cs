class Q619_BiggestSingleNumber : SqlQuestion
{
    public override string Query => 
    """
    SELECT COALESCE(
    (
        SELECT num FROM 
        (
            SELECT num
            FROM MyNumbers
            GROUP BY num
            HAVING count(num) = 1
            ORDER BY num DESC
            LIMIT 1
        )
    )
    , NULL) as num
    """;
}

class Q619_BiggestSingleNumberTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            """
            INSERT INTO MyNumbers VALUES
            (8),(8),(3),(3),(1),(4),(5),(6);
            """,
            6
        ],
        [
            """
            INSERT INTO MyNumbers VALUES
            (8),(8),(7),(7),(3),(3),(3);
            """,
            int.MinValue
        ]
    ];
}
[Trait("QuestionType", "SQL")]
public class Q619_BiggestSingleNumberTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema => 
    """
    CREATE TABLE IF NOT EXISTS MyNumbers (num INT);
    """;

    [Theory]
    [ClassData(typeof(Q619_BiggestSingleNumberTestData))]
    public void OfficialTestCases2(string testDataSql, int? expected)
    {
        ArrangeTestData(testDataSql);

        var sut = new Q619_BiggestSingleNumber();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["num"]);
        
        Assert.True(reader.Read());
        
        if(expected != int.MinValue)
        {
            Assert.Equal(expected, reader.GetInt32(0));
        }
        else
        {
            Assert.Equal(DBNull.Value, reader.GetValue(0));
        }

        reader.Close();
    }
}
