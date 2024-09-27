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
        ],
        [
            """
            insert into Employees (employee_id, name, manager_id, salary) values 
            ('18', 'Drew', NULL, '41568'),
            ('20', 'Ronan', '3', '65209'),
            ('10', 'Jaxton', '15', '96667'),
            ('13', 'Louie', '16', '6801'),
            ('17', 'Mylah', '20', '26540'),
            ('21', 'Kenia', '15', '98690'),
            ('7', 'Hadley', '6', '23590'),
            ('9', 'Hayden', '4', '90798'),
            ('2', 'Nixon', NULL, '25560'),
            ('8', 'Arthur', '11', '67027'),
            ('11', 'Brycen', NULL, '42570'),
            ('3', 'Noemi', NULL, '87321'),
            ('14', 'Hayden', NULL, '4123'),
            ('19', 'Astrid', '20', '37680');
            """,
            new int[] {7,13}
        ]
    ];
    private string Query =>
    """
    select e1.employee_id from Employees e1
    where e1.manager_id is not null
    left join 
    (select employee_id, name from Employees) e2
    on e1.manager_id = e2.employee_id
    where 
    e1.manager_id is not null 
    and e2.employee_id is null
    and e1.salary < 30000
    order by e1.employee_id;
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
