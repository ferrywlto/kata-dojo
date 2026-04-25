using Row = (int employee_id, int department_id);
class Q1789_PrimaryDepartmentForEachEmployee : SqlQuestion
{
    public override string Query =>
    """
    select 
        emp1.employee_id, 
        emp1.department_id
    from 
    Employee emp1
    left join
    (
        select 
            employee_id, 
            count(department_id) as 'count' 
        from 
        Employee
        group by 
            employee_id
    ) emp2 on emp1.employee_id = emp2.employee_id
    where emp1.primary_flag = 'Y' or emp2.count = 1
    """;
}
class Q1789_PrimaryDepartmentForEachEmployeeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Employee (employee_id, department_id, primary_flag) values
             ('1', '1', 'N'),
             ('2', '1', 'Y'),
             ('2', '2', 'N'),
             ('3', '3', 'N'),
             ('4', '2', 'N'),
             ('4', '3', 'Y'),
             ('4', '4', 'N');
            """,
            new Row[]
            {
                (1,1),
                (2,1),
                (3,3),
                (4,3),
            }
        ]
    ];
}
public class Q1789_PrimaryDepartmentForEachEmployeeTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Employee (employee_id int, department_id int, primary_flag CHAR(1) CHECK (primary_flag IN ('Y', 'N')));
    """;
    [Theory]
    [ClassData(typeof(Q1789_PrimaryDepartmentForEachEmployeeTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1789_PrimaryDepartmentForEachEmployee();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["employee_id", "department_id"]);
        foreach (var (employee_id, department_id) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(employee_id, reader.GetInt32(0));
            Assert.Equal(department_id, reader.GetInt32(1));
        }
    }
}

