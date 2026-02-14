public class Q1965_EmployeesWithMissingInformation(ITestOutputHelper output) : SqlTest(output)
{
    public static string Query =>
    """
    SELECT employee_id FROM 
    Employees e 
    WHERE employee_id NOT IN (SELECT employee_id FROM Salaries)

    UNION

    SELECT employee_id FROM 
    Salaries s
    WHERE employee_id NOT IN (SELECT employee_id FROM Employees)
    
    ORDER BY employee_id
    ;
    """;
    public static List<object[]> TestData =>
    [[
        """
        insert into Employees (employee_id, name) values 
        ('2', 'Crew'),
        ('4', 'Haven'),
        ('5', 'Kristian');
        insert into Salaries (employee_id, salary) values 
        ('5', '76071'),
        ('1', '22517'),
        ('4', '63539');
        """,
        new int[] {1,2}
    ]];

    protected override string TestSchema =>
    """
    Create table If Not Exists Employees (employee_id int, name varchar(30));
    Create table If Not Exists Salaries (employee_id int, salary int);
    """;

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string testDataSql, int[] expected)
    {
        ArrangeTestData(testDataSql);
        var reader = ExecuteQuery(Query, true);
        AssertResultSchema(reader, ["employee_id"]);
        foreach (var employee_id in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(employee_id, reader.GetInt32(0));
        }
    }
}
