using Row = (int employee_id, int bonus);
class Q1873_CalculateSpecialBonus : SqlQuestion
{
    public override string Query =>
    """
    select e1.employee_id, coalesce(e2.salary, 0) as 'bonus'  
    from Employees e1 left join
    (
        select employee_id, salary from Employees
        where employee_id % 2 = 1 
        and name not like 'M%'
    ) e2 on e1.employee_id = e2.employee_id
    order by e1.employee_id;
    """;
}
class Q1873_CalculateSpecialBonusTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Employees (employee_id, name, salary) values
             ('2', 'Meir', '3000'),
             ('3', 'Michael', '3800'),
             ('7', 'Addilyn', '7400'),
             ('8', 'Juan', '6100'),
             ('9', 'Kannon', '7700');            
            """,
            new Row[]
            {
                (2,0),
                (3,0),
                (7,7400),
                (8,0),
                (9,7700),
            }
        ]
    ];
}
public class Q1873_CalculateSpecialBonusTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Employees (employee_id int, name varchar(30), salary int);
    """;
    [Theory]
    [ClassData(typeof(Q1873_CalculateSpecialBonusTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1873_CalculateSpecialBonus();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["employee_id", "bonus"]);
        foreach ((var employee_id, var bonus) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(employee_id, reader.GetInt32(0));
            Assert.Equal(bonus, reader.GetInt32(1));
        }
    }
}
