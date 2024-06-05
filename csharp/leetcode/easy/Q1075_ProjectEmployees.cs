
class Q1075_ProjectEmployees : SqlQuestion
{
    public override string Query => 
    """
    select p.project_id, ROUND(AVG(e.experience_years), 2) as average_years
    from Project p left join Employee e
    on p.employee_id = e.employee_id
    group by p.project_id;
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
[Trait("QuestionType", "SQL")]
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
        AssertResultSchema(reader, ["project_id", "average_years"]);

        Assert.True(reader.Read());
        Assert.Equal(1, reader.GetInt32(0));
        Assert.Equal(2, reader.GetDouble(1));

        Assert.True(reader.Read());
        Assert.Equal(2, reader.GetInt32(0));
        Assert.Equal(2.5, reader.GetDouble(1));
    }
}