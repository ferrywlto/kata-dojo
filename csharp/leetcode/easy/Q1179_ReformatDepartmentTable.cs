
using Microsoft.Data.Sqlite;

class Q1179_ReformatDepartmentTable : SqlQuestion
{
    public override string Query => 
    """
    select 1;
    """;
}
class Q1179_ReformatDepartmentTableTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            """
            insert into Department (id, revenue, month) values 
            ('1', '8000', 'Jan'),
            ('2', '9000', 'Jan'),
            ('3', '10000', 'Feb'),
            ('1', '7000', 'Feb'),
            ('1', '6000', 'Mar');
            """
        ],
    ];
}
public class Q1179_ReformatDepartmentTableTests(ITestOutputHelper output): SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Department (id int, revenue int, month varchar(5));
    """;

    [Theory]
    [ClassData(typeof(Q1179_ReformatDepartmentTableTestData))]
    public override void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1179_ReformatDepartmentTable();
        var reader = ExecuteQuery(sut.Query, true);

        AssertResultSchema(reader, ["id", 
            "Jan_Revenue", 
            "Feb_Revenue", 
            "Mar_Revenue",
            "Apr_Revenue",
            "May_Revenue",
            "Jun_Revenue",
            "Jul_Revenue",
            "Aug_Revenue",
            "Sep_Revenue",
            "Oct_Revenue",
            "Nov_Revenue",
            "Dec_Revenue",
        ]);

        AssertRow(reader, [1, 8000, 7000, 6000, null, null, null, null, null, null, null, null, null]);
        AssertRow(reader, [2, 9000, null, null, null, null, null, null, null, null, null, null, null]);
        AssertRow(reader, [3, null, 10000, null, null, null, null, null, null, null, null, null, null]);

        void AssertRow(SqliteDataReader reader, int?[] input)
        {
            Assert.True(reader.Read());
            for(var i=0; i<input.Length; i++)
            {
                Assert.Equal(input[i], reader.GetInt32(i));
            }
        }
    }
}