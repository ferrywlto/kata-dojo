
using System.Data.Common;

namespace dojo.leetcode;

public class Q627_SwapSalary : SqlQuestion
{
    public override string Query =>
    """
    SELECT 1
    """;
}

public class Q627_SwapSalaryTestData : TestData
{
    protected override List<object[]> Data => 
    [[
        """
        INSERT INTO Salary VALUES
        (1, 'A', 'm', 2500),
        (2, 'B', 'f', 1500),
        (3, 'C', 'm', 5500),
        (4, 'D', 'f', 500)
        """
    ]];
}

public class Q627_SwapSalaryTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema => 
    """
    CREATE TABLE IF NOT EXISTS Salary (id INT, name VARCHAR, sex ENUM, salary INT)
    """;

    [Theory]
    [ClassData(typeof(Q627_SwapSalaryTestData))]
    public override void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);

        var sut = new Q627_SwapSalary();
        ExecuteCommand(sut.Query);
        var reader = ExecuteQuery("SELECT * FROM Salary", true);

        AssertReader(reader);
    }

    private void AssertReader(DbDataReader reader)
    {
        Assert.True(reader.HasRows);
        Assert.Equal(4, reader.FieldCount);
        Assert.Equal("id", reader.GetName(0));
        Assert.Equal("name", reader.GetName(1));
        Assert.Equal("sex", reader.GetName(2));
        Assert.Equal("salary", reader.GetName(3));

        AssertRow(reader, 1, "A", 'f', 2500);
        AssertRow(reader, 2, "B", 'm', 2500);
        AssertRow(reader, 3, "C", 'f', 2500);
        AssertRow(reader, 4, "D", 'm', 2500);
    }

    private void AssertRow(DbDataReader reader, int id, string name, char sex, int salary)
    {
        Assert.Equal(id, reader.GetInt32(0));
        Assert.Equal(name, reader.GetString(1));
        Assert.Equal(sex, reader.GetChar(2));
        Assert.Equal(salary, reader.GetInt32(3));
    }
}