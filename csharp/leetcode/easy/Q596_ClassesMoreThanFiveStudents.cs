class Q596_ClassesMoreThanFiceStudents : SqlQuestion
{
    public override string Query =>
    """
    SELECT class 
    FROM courses 
    GROUP BY class
    HAVING count(class) > 4;
    """;
}

class Q596_ClassesMoreThanFiceStudentsTestData : TestData
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
[Trait("QuestionType", "SQL")]
public class Q596_ClassesMoreThanFiceStudentsTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Courses (student VARCHAR, class VARCHAR);
    """;

    [Theory]
    [ClassData(typeof(Q596_ClassesMoreThanFiceStudentsTestData))]
    public override void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);

        var sut = new Q596_ClassesMoreThanFiceStudents();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["class"]);

        Assert.True(reader.Read());
        Assert.Equal("Math", reader.GetString(0));
    }
}