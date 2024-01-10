
using dojo.leetcode;


public class Q181_EmployeesEarningMoreThanTheirManagersTestData : TestDataBase
{
    protected override List<object[]> Data =>
    [
        [
            """
            INSERT INTO Employee VALUES (1, 'Joe', 70000, 3);
            INSERT INTO Employee VALUES (2, 'Henry', 80000, 4);
            INSERT INTO Employee VALUES (3, 'Sam', 60000, NULL);
            INSERT INTO Employee VALUES (4, 'Max', 90000, NULL);
            """
        ],
    ];
}

public class Q181_EmployeesEarningMoreThanTheirManagersTests(ITestOutputHelper output) : DatabaseTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Employee (id INT, name VARCHAR(255), salary INT, managerId INT);
    """;

    [Theory]
    [ClassData(typeof(Q181_EmployeesEarningMoreThanTheirManagersTestData))]
    public void OfficialTestCases(string input)
    {
        InputTestData(input);

        var sut = new Q181_EmployeesEarningMoreThanTheirManagers();
        
        var reader = Execute(sut.Query);

        Assert.True(reader.HasRows);
        Assert.Equal(1, reader.FieldCount);
        Assert.True(reader.Read());
        Assert.Equal("Joe", reader.GetString(0));
    }
    
}

public class Q181_EmployeesEarningMoreThanTheirManagers
{
    public string Query =>
    """
    SELECT e1.Name AS Employee From Employee e1 LEFT JOIN Employee e2 on e1.managerId = e2.id WHERE e1.salary > e2.salary  
    """;
}