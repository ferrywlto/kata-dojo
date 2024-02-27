namespace dojo.leetcode;

public class Q596_ClassesMoreThanFiceStudents : SqlQuestion
{
    public override string Query =>
    """
    SELECT class 
    FROM courses 
    GROUP BY class
    HAVING count(class) > 4;
    """;
}

public class Q596_ClassesMoreThanFiceStudentsTestData : TestData
{
    protected override List<object[]> Data =>
    [[
        """
        INSERT INTO Courses VALUES
        ('A', 'Math'    ),
        ('B', 'English' ),
        ('C', 'Math'    ),
        ('D', 'Biology' ),
        ('E', 'Math'    ),
        ('F', 'Computer'),
        ('G', 'Math'    ),
        ('H', 'Math'    ),
        ('I', 'Math'    );
        """
    ]];
}

public class Q596_ClassesMoreThanFiceStudentsTest(ITestOutputHelper output) : DatabaseTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Courses (student VARCHAR, class VARCHAR);
    """;

    [Theory]
    [ClassData(typeof(Q596_ClassesMoreThanFiceStudentsTestData))]
    public override void OfficialTestCases(string testDataSql)
    {
        InputTestData(testDataSql);

        var sut = new Q596_ClassesMoreThanFiceStudents();
        var reader = ExecuteQuery(sut.Query);

        Assert.True(reader.HasRows);
        Assert.Equal(1, reader.FieldCount);
        Assert.Equal("class", reader.GetName(0));

        Assert.True(reader.Read());
        Assert.Equal("Math", reader.GetString(0));
    }
}