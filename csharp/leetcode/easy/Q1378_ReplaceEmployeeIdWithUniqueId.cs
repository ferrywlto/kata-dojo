using Row = (int? unique_id, string name);
class Q1378_ReplaceEmployeeIdWithUniqueId : SqlQuestion
{
    public override string Query =>
    """
    select 1;
    """;
}
class Q1378_ReplaceEmployeeIdWithUniqueIdTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Employees (id, name) values
            ('1', 'Alice'),
            ('7', 'Bob'),
            ('11', 'Meir'),
            ('90', 'Winston'),
            ('3', 'Jonathan');
            
            insert into EmployeeUNI (id, unique_id) values
            ('3', '1'),
            ('11', '2'),
            ('90', '3');
            """,
            new Row[] {
                new(null, "Alice"),
                new(null, "Bob"),
                new(2, "Meir"),
                new(3, "Winston"),
                new(1, "Jonathan"),
            }
        ]
    ];
}
public class Q1378_ReplaceEmployeeIdWithUniqueIdTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Employees (id int, name varchar(20));
    Create table If Not Exists EmployeeUNI (id int, unique_id int);
    """;

    [Theory]
    [ClassData(typeof(Q1378_ReplaceEmployeeIdWithUniqueIdTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1378_ReplaceEmployeeIdWithUniqueId();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["unique_id", "name"]);
        foreach (var (unique_id, name) in expected)
        {
            Assert.True(reader.Read());
            if (unique_id == null)
                Assert.True(reader.IsDBNull(0));
            else
                Assert.Equal(unique_id, reader.GetInt32(0));
            Assert.Equal(name, reader.GetString(1));
        }
    }
}