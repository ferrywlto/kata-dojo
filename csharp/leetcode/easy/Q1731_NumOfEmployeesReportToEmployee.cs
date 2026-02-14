using Row = (int employee_id, string name, int reports_count, double average_age);
class Q1731_NumOfEmployeesReportToEmployee : SqlQuestion
{
    // MySQL Dialect
    public override string Query =>
    """
    select 
    managers.employee_id as 'employee_id', 
    managers.name as 'name', 
    count(reports.name) as 'reports_count', 
    round(avg(reports.age)) as 'average_age'
    from Employees managers 
    left join Employees reports
    on reports.reports_to = managers.employee_id
    group by managers.employee_id
    having count(reports.name) > 0
    order by managers.employee_id;
    """;
    // T-SQL Dialect
    /*
    select 
    managers.employee_id as 'employee_id', 
    managers.name as 'name', 
    count(reports.name) as 'reports_count', 
    round(avg(CAST(reports.age AS FLOAT)), 0) as 'average_age'
    from Employees managers 
    left join Employees reports
    on reports.reports_to = managers.employee_id
    group by managers.employee_id, managers.name
    having count(reports.name) > 0
    order by managers.employee_id;    
    */
}
class Q1731_NumOfEmployeesReportToEmployeeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Employees (employee_id, name, reports_to, age) values
             ('9', 'Hercy', null, '43'),
             ('6', 'Alice', '9', '41'),
             ('4', 'Bob', '9', '36'),
             ('2', 'Winston', null, '37');
            """,
            new Row[]
            {
                (9, "Hercy", 2, 39),
            }
        ],
        [
            """
            insert into Employees (employee_id, name, reports_to, age) values
             ('1', 'Michael', null, '45'),
             ('2', 'Alice', '1', '38'),
             ('3', 'Bob', '1', '42'),
             ('4', 'Charlie', '2', '34'),
             ('5', 'David', '2', '40'),
             ('6', 'Eve', '3', '37'),
             ('7', 'Frank', null, '50'),
             ('8', 'Grace', null, '48');
            """,
            new Row[]
            {
                (1, "Michael", 2, 40),
                (2, "Alice", 2, 37),
                (3, "Bob", 1, 37),
            }
        ]
    ];
}
public class Q1731_NumOfEmployeesReportToEmployeeTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Employees(employee_id int, name varchar(20), reports_to int, age int);
    """;

    [Theory]
    [ClassData(typeof(Q1731_NumOfEmployeesReportToEmployeeTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1731_NumOfEmployeesReportToEmployee();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["employee_id", "name", "reports_count", "average_age"]);
        foreach (var (employee_id, name, reports_count, average_age) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(employee_id, reader.GetInt32(0));
            Assert.Equal(name, reader.GetString(1));
            Assert.Equal(reports_count, reader.GetInt32(2));
            Assert.Equal(average_age, reader.GetDouble(3));
        }
    }
}
