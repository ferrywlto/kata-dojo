using Microsoft.Data.Sqlite;

class Q1179_ReformatDepartmentTable : SqlQuestion
{
    public override string Query =>
    """
    select distinct
        d.id, 
        jan.revenue as 'Jan_Revenue', 
        feb.revenue as 'Feb_Revenue',
        mar.revenue as 'Mar_Revenue',
        apr.revenue as 'Apr_Revenue',
        may.revenue as 'May_Revenue',
        jun.revenue as 'Jun_Revenue',
        jul.revenue as 'Jul_Revenue',
        aug.revenue as 'Aug_Revenue',
        sep.revenue as 'Sep_Revenue',
        oct.revenue as 'Oct_Revenue',
        nov.revenue as 'Nov_Revenue',
        dec.revenue as 'Dec_Revenue'
    from Department d 
        left join Department jan on d.id = jan.id and jan.month = 'Jan'
        left join Department feb on d.id = feb.id and feb.month = 'Feb'
        left join Department mar on d.id = mar.id and mar.month = 'Mar'
        left join Department apr on d.id = apr.id and apr.month = 'Apr'
        left join Department may on d.id = may.id and may.month = 'May'
        left join Department jun on d.id = jun.id and jun.month = 'Jun'
        left join Department jul on d.id = jul.id and jul.month = 'Jul'
        left join Department aug on d.id = aug.id and aug.month = 'Aug'
        left join Department sep on d.id = sep.id and sep.month = 'Sep'
        left join Department oct on d.id = oct.id and oct.month = 'Oct'
        left join Department nov on d.id = nov.id and nov.month = 'Nov'
        left join Department dec on d.id = dec.id and dec.month = 'Dec'
    order by d.id asc;
    """;
}
class Q1179_ReformatDepartmentTableTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Department (id, revenue, month) values 
            ('1', '8000', 'Jan'),
            ('2', '9000', 'Jan'),
            ('3', '10000', 'Feb'),
            ('1', '7000', 'Feb'),
            ('1', '6000', 'Mar');
            """,
            new int?[][] {
                [1, 8000, 7000, 6000, null, null, null, null, null, null, null, null, null],
                [2, 9000, null, null, null, null, null, null, null, null, null, null, null],
                [3, null, 10000, null, null, null, null, null, null, null, null, null, null],
            }
        ],
        [
            """
            insert into Department (id, revenue, month) values 
            ('17', '5765', 'Jun'),
            ('5 ', '8607', 'Sep'),
            ('24', '4325', 'Jan'),
            ('41', '2319', 'Jan'),
            ('38', '7830', 'Mar'),
            ('29', '6438', 'Sep'),
            ('6 ', '6406', 'May'),
            ('8 ', '7496', 'Aug'),
            ('32', '4201', 'Aug'),
            ('39', '9990', 'Apr');
            """,
            new int?[][] {
                [5,null,null,null,null,null,null,null,null,8607,null,null,null],
                [6,null,null,null,null,6406,null,null,null,null,null,null,null],
                [8,null,null,null,null,null,null,null,7496,null,null,null,null],
                [17,null,null,null,null,null,5765,null,null,null,null,null,null],
                [24,4325,null,null,null,null,null,null,null,null,null,null,null],
                [29,null,null,null,null,null,null,null,null,6438,null,null,null],
                [32,null,null,null,null,null,null,null,4201,null,null,null,null],
                [38,null,null,7830,null,null,null,null,null,null,null,null,null],
                [39,null,null,null,9990,null,null,null,null,null,null,null,null],
                [41,2319,null,null,null,null,null,null,null,null,null,null,null],
            }
        ]
    ];
}
public class Q1179_ReformatDepartmentTableTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Department (id int, revenue int, month varchar(5));
    """;

    [Theory]
    [ClassData(typeof(Q1179_ReformatDepartmentTableTestData))]
    public void OfficialTestCases(string testDataSql, int?[][] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1179_ReformatDepartmentTable();
        var reader = ExecuteQuery(sut.Query);

        AssertResultSchema(reader, ["id",
            "Jan_Revenue",
            "Feb_Revenue",
            "Mar_Revenue",
            "Apr_Revenue",
            "May_Revenue",
            "Jun_Revenue",
            "Jul_Revenue",
            "Aug_Revenue",
            "Sep_Revenue",
            "Oct_Revenue",
            "Nov_Revenue",
            "Dec_Revenue",
        ]);
        for (var i = 0; i < expected.Length; i++)
            AssertRow(reader, expected[i]);

        void AssertRow(SqliteDataReader reader, int?[] input)
        {
            Assert.True(reader.Read());
            for (var i = 0; i < input.Length; i++)
            {
                if (reader.IsDBNull(i))
                    Assert.Null(input[i]);
                else
                    Assert.Equal(input[i], reader.GetInt32(i));
            }
        }
    }
}