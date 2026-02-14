using Row = (string date_id, string make_name, int unique_leads, int unique_partners);
class Q1693_DailyLeadsAndPartners : SqlQuestion
{
    public override string Query =>
    """
    select date_id, make_name, 
    count(distinct lead_id) as 'unique_leads', 
    count(distinct partner_id) as 'unique_partners'
    from DailySales
    group by date_id, make_name
    order by 
     make_name desc,
     date_id desc;
    """;
}
class Q1693_DailyLeadsAndPartnersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into DailySales (date_id, make_name, lead_id, partner_id) values 
            ('2020-12-8', 'toyota', '0', '1'),
            ('2020-12-8', 'toyota', '1', '0'),
            ('2020-12-8', 'toyota', '1', '2'),
            ('2020-12-7', 'toyota', '0', '2'),
            ('2020-12-7', 'toyota', '0', '1'),
            ('2020-12-8', 'honda', '1', '2'),
            ('2020-12-8', 'honda', '2', '1'),
            ('2020-12-7', 'honda', '0', '1'),
            ('2020-12-7', 'honda', '1', '2'),
            ('2020-12-7', 'honda', '2', '1');           
            """,
            new Row[]
            {
                ("2020-12-8", "toyota", 2, 3),
                ("2020-12-7", "toyota", 1, 2),
                ("2020-12-8", "honda", 2, 2),
                ("2020-12-7", "honda", 3, 2),
            }
        ]
    ];
}
public class Q1693_DailyLeadsAndPartnersTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists DailySales(date_id date, make_name varchar(20), lead_id int, partner_id int);
    """;
    [Theory]
    [ClassData(typeof(Q1693_DailyLeadsAndPartnersTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1693_DailyLeadsAndPartners();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["date_id", "make_name", "unique_leads", "unique_partners"]);
        foreach (var row in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(row.date_id, reader.GetDateTimeOffset(0).ToString("yyyy-MM-d"));
            Assert.Equal(row.make_name, reader.GetString(1));
            Assert.Equal(row.unique_leads, reader.GetInt32(2));
            Assert.Equal(row.unique_partners, reader.GetInt32(3));
        }
    }
}

