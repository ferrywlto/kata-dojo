using Row = (int user_id, string name);
class Q1667_FixNamesInTable : SqlQuestion
{
    // MySQL dialect:
    // concat(upper(substring(name, 1, 1)), lower(substring(name, 2))) AS 'name'
    public override string Query =>
    """
    select user_id,
    upper(substring(name, 1, 1)) || lower(substring(name, 2)) AS 'name'
    from Users
    order by user_id;
    """;
}
class Q1667_FixNamesInTableTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Users (user_id, name) values ('1', 'aLice');
            insert into Users (user_id, name) values ('2', 'bOB');
            """,
            new Row[]
            {
                (1, "Alice"),
                (2, "Bob"),
            }
        ]
    ];
}
public class Q1667_FixNamesInTableTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Users (user_id int, name varchar(40));
    """;

    [Theory]
    [ClassData(typeof(Q1667_FixNamesInTableTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1667_FixNamesInTable();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["user_id", "name"]);
        foreach ((int user_id, string name) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(user_id, reader.GetInt32(0));
            Assert.Equal(name, reader.GetString(1));
        }
    }
}