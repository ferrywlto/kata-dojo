public class Q1978_EmployeesWhoseManagerLeftTheCompany(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Employees (employee_id int, name varchar(20), manager_id int, salary int);
    """;
    public static List<object[]> TestData =>
    [
        [
            """
            insert into Employees (employee_id, name, manager_id, salary) values 
            ('3', 'Mila', '9', '60301'),
            ('12', 'Antonella', NULL, '31000'),
            ('13', 'Emery', NULL, '67084'),
            ('1', 'Kalel', '11', '21241'),
            ('9', 'Mikaela', NULL, '50937'),
            ('11', 'Joziah', '6', '28485');
            """,
            new int[] {11},
        ]
    ];
    private string Query => "select 1;";
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
