using Row = (string day, int emp_id, int total_time);
class Q1741_FindTotalTimeSpentByEachEmployee : SqlQuestion
{
    public override string Query =>
    """
    select 
    event_day as 'day', 
    emp_id, 
    sum(out_time - in_time) as 'total_time'
    from Employees
    group by event_day, emp_id;
    """;
}
class Q1741_FindTotalTimeSpentByEachEmployeeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Employees (emp_id, event_day, in_time, out_time) values 
            ('1', '2020-11-28', '4', '32'),
            ('1', '2020-11-28', '55', '200'),
            ('1', '2020-12-3', '1', '42'),
            ('2', '2020-11-28', '3', '33'),
            ('2', '2020-12-9', '47', '74');
            """,
            new Row[]
            {
                ("2020-11-28", 1, 173),
                ("2020-11-28", 2, 30),
                ("2020-12-03", 1, 41),
                ("2020-12-09", 2, 27),
            }
        ]
    ];
}
public class Q1741_FindTotalTimeSpentByEachEmployeeTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Employees(emp_id int, event_day date, in_time int, out_time int);
    """;
    [Theory]
    [ClassData(typeof(Q1741_FindTotalTimeSpentByEachEmployeeTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1741_FindTotalTimeSpentByEachEmployee();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["day", "emp_id", "total_time"]);
        foreach ((var day, var emp_id, var total_time) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(day, reader.GetDateTime(0).ToString("yyyy-MM-dd"));
            Assert.Equal(emp_id, reader.GetInt32(1));
            Assert.Equal(total_time, reader.GetInt32(2));
        }
    }
}
