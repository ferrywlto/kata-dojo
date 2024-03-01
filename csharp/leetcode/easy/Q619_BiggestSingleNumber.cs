
namespace dojo.leetcode;

public class Q619_BiggestSingleNumber : SqlQuestion
{
    public override string Query => 
    """
    SELECT 1;
    """;
}

public class Q619_BiggestSingleNumberTestData : TestData
{
    protected override List<object[]> Data => 
    [[
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
        -1
    ]];
}

public class Q619_BiggestSingleNumberTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema => 
    """
    CREATE TABLE IF NOT EXISTS MyNumbers (num INT);
    """;

    [Theory]
    [ClassData(typeof(Q619_BiggestSingleNumberTestData))]
    public void OfficialTestCases2(string testDataSql, int expected)
    {
        ArrangeTestData(testDataSql);

        var sut = new Q619_BiggestSingleNumber();
        var reader = ExecuteQuery(sut.Query, true);

        Assert.True(reader.HasRows);
        Assert.Equal(1, reader.FieldCount);
        
        Assert.True(reader.Read());
        Assert.Equal(expected, reader.GetInt32(0));

        Assert.False(reader.Read());
    }

    [Theory(Skip = "Override")]
    [ClassData(typeof(Q619_BiggestSingleNumberTestData))]
    public override void OfficialTestCases(string testDataSql)
    {
        Assert.True(!string.IsNullOrEmpty(testDataSql));
    }
}
