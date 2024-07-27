using Row = (int patient_id, string patient_name, string conditions);
class Q1527_PatientsWithACondition : SqlQuestion
{
    public override string Query =>
    """
    select * from Patients
    where conditions like '% DIAB1%' or conditions like 'DIAB1%';
    """;
}
class Q1527_PatientsWithAConditionTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Patients (patient_id, patient_name, conditions) values
             ('1', 'Daniel', 'YFEV COUGH'),
             ('2', 'Alice', ''),
             ('3', 'Bob', 'DIAB100 MYOP'),
             ('4', 'George', 'ACNE DIAB100'),
             ('5', 'Alain', 'DIAB201');
            """,
            new Row[]
            {
                (3, "Bob", "DIAB100 MYOP"),
                (4, "George", "ACNE DIAB100"),
            }
        ]
    ];
}
public class Q1527_PatientsWithAConditionTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Patients (patient_id int, patient_name varchar(30), conditions varchar(100));
    """;

    [Theory]
    [ClassData(typeof(Q1527_PatientsWithAConditionTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1527_PatientsWithACondition();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["patient_id", "patient_name", "conditions"]);
        foreach ((int patient_id, string patient_name, string conditions) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(patient_id, reader.GetInt32(0));
            Assert.Equal(patient_name, reader.GetString(1));
            Assert.Equal(conditions, reader.GetString(2));
        }
    }
}