class Q577_EmployeeBonus : SqlQuestion
{
    public override string Query =>
    """
    SELECT name, bonus FROM Employee emp 
    LEFT JOIN Bonus b 
    ON emp.empId = b.empId
    WHERE bonus is NULL
    OR bonus < 1000;
    """;
}

class Q577_EmployeeBonusTestData : TestData
{
    protected override List<object[]> Data =>
    [[
        """
        INSERT INTO Employee VALUES 
        (3, 'Brad', null, 4000), 
        (1, 'John', 3, 1000),
        (2, 'Dan', 3, 2000),
        (4, 'Thomas', 3, 4000);

        INSERT INTO Bonus VALUES
        (2, 500),
        (4, 2000);
        """
    ]];
}
[Trait("QuestionType", "SQL")]
public class Q577_EmployeeBonusTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Employee (empId INT, name VARCHAR, supervisor INT, salary INT);
    CREATE TABLE IF NOT EXISTS Bonus (empId INT, bonus INT);
    """;

    [Theory]
    [ClassData(typeof(Q577_EmployeeBonusTestData))]
    public void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);

        var sut = new Q577_EmployeeBonus();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["name", "bonus"]);

        Assert.True(reader.Read());
        Assert.Equal("Brad", reader.GetString(0));
        Assert.True(reader.IsDBNull(1));

        Assert.True(reader.Read());
        Assert.Equal("John", reader.GetString(0));
        Assert.True(reader.IsDBNull(1));

        Assert.True(reader.Read());
        Assert.Equal("Dan", reader.GetString(0));
        Assert.Equal(500, reader.GetInt32(1));
    }
}