using Row = (int student_id, string student_name, string subject_name, int attended_exams);
class Q1280_StudentsAndExaminations : SqlQuestion
{
    public override string Query => 
    """
    select s.student_id, student_name, sub.subject_name, count(e.subject_name) as attended_exams
    from Students s
    join Subjects sub
    on 1=1
    left join Examinations e 
    on s.student_id = e.student_id and sub.subject_name = e.subject_name
    group by s.student_id, student_name, sub.subject_name;
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
            """,
            new Row[]
            {
                (1, "Alice", "Math", 3), 
                (1, "Alice", "Physics", 2), 
                (1, "Alice", "Programming", 1), 
                (2, "Bob", "Math", 1), 
                (2, "Bob", "Physics", 0), 
                (2, "Bob", "Programming", 1), 
                (6, "Alex", "Math", 0), 
                (6, "Alex", "Physics", 0), 
                (6, "Alex", "Programming", 0), 
                (13, "John", "Math", 1), 
                (13, "John", "Physics", 1), 
                (13, "John", "Programming", 1),                 
            },
        ],
    ];
}
public class Q1280_StudentsAndExaminationsTests : SqlTest
{
    protected override string TestSchema => 
    """
    Create table If Not Exists Students (student_id int, student_name varchar(20));
    Create table If Not Exists Subjects (subject_name varchar(20));
    Create table If Not Exists Examinations (student_id int, subject_name varchar(20));
    """;

    [Theory]
    [ClassData(typeof(Q1280_StudentsAndExaminationsTestData))]
    public void OfficialTestCases(string testDataSql, Row[] values)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1280_StudentsAndExaminations();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["student_id", "student_name", "subject_name", "attended_exams"]);

        for(var i = 0; i< values.Length; i++)
        {
            Assert.True(reader.Read());
            Assert.Equal(values[i].student_id, reader.GetInt32(0));
            Assert.Equal(values[i].student_name, reader.GetString(1));
            Assert.Equal(values[i].subject_name, reader.GetString(2));
            Assert.Equal(values[i].attended_exams, reader.GetInt32(3));
        }        
    }
}
