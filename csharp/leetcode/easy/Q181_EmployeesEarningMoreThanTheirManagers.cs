class Q181_EmployeesEarningMoreThanTheirManagers : SqlQuestion
{
    public override string Query =>
    """
    SELECT e1.Name AS Employee 
    FROM Employee e1 
    LEFT JOIN Employee e2 
    ON e1.managerId = e2.id 
    WHERE e1.salary > e2.salary;  
    """;
}

class Q181_EmployeesEarningMoreThanTheirManagersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            INSERT INTO Employee VALUES
            (1, 'Joe', 70000, 3),
            (2, 'Henry', 80000, 4),
            (3, 'Sam', 60000, NULL),
            (4, 'Max', 90000, NULL);
            """
        ],
    ];
}
[Trait("QuestionType", "SQL")]
public class Q181_EmployeesEarningMoreThanTheirManagersTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Employee (id INT, name VARCHAR, salary INT, managerId INT);
    """;

    [Theory]
    [ClassData(typeof(Q181_EmployeesEarningMoreThanTheirManagersTestData))]
    public void OfficialTestCases(string input)
    {
        ArrangeTestData(input);

        var sut = new Q181_EmployeesEarningMoreThanTheirManagers();

        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["Employee"]);

        Assert.True(reader.Read());
        Assert.Equal("Joe", reader.GetString(0));
    }

}
