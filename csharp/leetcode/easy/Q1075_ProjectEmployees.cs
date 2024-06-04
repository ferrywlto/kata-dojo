
class Q1075_ProjectEmployees : SqlQuestion
{
    public override string Query => 
    """
    SELECT 1;
    """;
}
class Q1075_ProjectEmployeesTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            """
            insert into Project (project_id, employee_id) values 
            ('1', '1'), 
            ('1', '2'),
            ('1', '3'),
            ('2', '1'),
            ('2', '4');
            
            insert into Employee (employee_id, name, experience_years) values 
            ('1', 'Khaled', '3'),
            ('2', 'Ali', '2'),
            ('3', 'John', '1'),
            ('4', 'Doe', '2');
            """
        ]
    ];
}
public class Q1075_ProjectEmployeesTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema => 
    """
    Create table If Not Exists Project (project_id int, employee_id int);
    Create table If Not Exists Employee (employee_id int, name varchar(10), experience_years int);
    """;

    [Theory]
    [ClassData(typeof(Q1075_ProjectEmployeesTestData))]
    public override void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);

        var sut = new Q1075_ProjectEmployees();
        var reader = ExecuteQuery(sut.Query, true);

        Assert.True(reader.HasRows);
        Assert.Equal("project_id", reader.GetName(0));
        Assert.Equal("average_years", reader.GetName(1));
    }
}
