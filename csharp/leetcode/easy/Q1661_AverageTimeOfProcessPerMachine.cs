using Row = (int machine_id, double processing_time);
class Q1661_AverageTimeOfProcessPerMachine : SqlQuestion
{
    public override string Query =>
    """
    select machine_id, round(avg(processing_time), 3) as 'processing_time' from
    (
        select act_start.machine_id, act_start.process_id, (act_end.timestamp - act_start.timestamp) as 'processing_time' from 
        (select * from Activity where activity_type = 'start') act_start 
        join 
        (select * from Activity where activity_type = 'end') act_end
        on act_start.machine_id = act_end.machine_id
        and act_start.process_id = act_end.process_id 
    ) temp
    group by machine_id
    """;
}
class Q1661_AverageTimeOfProcessPerMachineTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Activity (machine_id, process_id, activity_type, timestamp) values 
            ('0', '0', 'start', '0.712'),
            ('0', '0', 'end', '1.52'),
            ('0', '1', 'start', '3.14'),
            ('0', '1', 'end', '4.12'),
            ('1', '0', 'start', '0.55'),
            ('1', '0', 'end', '1.55'),
            ('1', '1', 'start', '0.43'),
            ('1', '1', 'end', '1.42'),
            ('2', '0', 'start', '4.1'),
            ('2', '0', 'end', '4.512'),
            ('2', '1', 'start', '2.5'),
            ('2', '1', 'end', '5');
            """,
            new Row[]
            {
                (0, 0.894),
                (1, 0.995),
                (2, 1.456),
            }
        ]
    ];
}
public class Q1661_AverageTimeOfProcessPerMachineTests : SqlTest
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Activity (
        machine_id int, 
        process_id int, 
        activity_type text check(activity_type IN ('start', 'end')), 
        timestamp float
    );
    """;

    [Theory]
    [ClassData(typeof(Q1661_AverageTimeOfProcessPerMachineTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1661_AverageTimeOfProcessPerMachine();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["machine_id", "processing_time"]);
        foreach ((var machine_id, var processing_time) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(machine_id, reader.GetInt32(0));
            Assert.Equal(Math.Round(processing_time, 3), Math.Round(reader.GetDouble(1), 3));
        }
    }
}