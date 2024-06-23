
class Q1280_StudentsAndExaminations : SqlQuestion
{
    public override string Query => 
    """
    select 1;
    """;
}
class Q1280_StudentsAndExaminationsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            """
            insert into Students (student_id, student_name) values 
            ('1', 'Alice'),
            ('2', 'Bob'),
            ('13', 'John'),
            ('6', 'Alex');

            insert into Subjects (subject_name) values 
            ('Math'),
            ('Physics'),
            ('Programming');

            insert into Examinations (student_id, subject_name) values 
            ('1', 'Math'),
            ('1', 'Physics'),
            ('1', 'Programming'),
            ('2', 'Programming'),
            ('1', 'Physics'),
            ('1', 'Math'),
            ('13', 'Math'),
            ('13', 'Programming'),
            ('13', 'Physics'),
            ('2', 'Math'),
            ('1', 'Math');
            """
        ],
    ];
}
public class Q1280_StudentsAndExaminationsTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema => 
    """
    Create table If Not Exists Students (student_id int, student_name varchar(20));
    Create table If Not Exists Subjects (subject_name varchar(20));
    Create table If Not Exists Examinations (student_id int, subject_name varchar(20));
    """;

    [Theory]
    [ClassData(typeof(Q1280_StudentsAndExaminationsTestData))]
    public void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1280_StudentsAndExaminations();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["student_id", "student_name", "subject_name", "attended_exams"]);

    }
}
