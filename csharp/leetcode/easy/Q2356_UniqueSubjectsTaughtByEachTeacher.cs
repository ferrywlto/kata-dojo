using Row = (int teacher_id, int cnt);
public class Q2356_UniqueSubjectsTaughtByEachTeacher(ITestOutputHelper output) : SqlTest(output)
{
    public string Query => "select 1;";

    public static List<object[]> TestData =>
    [
        [
            """
            insert into Teacher (teacher_id, subject_id, dept_id) values 
            ('1', '2', '3'),
            ('1', '2', '4'),
            ('1', '3', '3'),
            ('2', '1', '1'),
            ('2', '2', '1'),
            ('2', '3', '1'),
            ('2', '4', '1');    
            """,
            new Row[]
            {
                (1, 2),
                (2, 4),
            },
        ],
    ];
    protected override string TestSchema =>
    """
    Create table If Not Exists Teacher (teacher_id int, subject_id int, dept_id int)
    Truncate table Teacher
    """;

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var reader = ExecuteQuery(Query, true);
        AssertResultSchema(reader, ["teacher_id", "cnt"]);
        foreach (var (teacher_id, cnt) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(teacher_id, reader.GetInt32(0));
            Assert.Equal(cnt, reader.GetInt32(1));
        }
    }
}