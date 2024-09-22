using Row = (string sell_date, int num_sold, string products);
class Q1484_GroupSoldProductsByDate : SqlQuestion
{
    public override string Query =>
    """
    select sell_date, count(distinct product) as 'num_sold', group_concat(distinct product) AS products 
    from (select distinct * from Activities order by sell_date, product asc) distinct_sales
    group by sell_date
    order by date(sell_date) asc;
    """;
    /* MySQL version 
    select sell_date, count(distinct product) as 'num_sold', 
    group_concat(distinct product) AS products 
    from (select distinct sell_date, product from Activities order by sell_date, product asc) sales
    group by sell_date
    order by date(sell_date) asc;
    */
    // T-SQL use string_agg() instead of group_concat()
}
class Q1484_GroupSoldProductsByDateTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Activities (sell_date, product) values 
            ('2020-05-30', 'Headphone'),
            ('2020-06-01', 'Pencil'),
            ('2020-06-02', 'Mask'),
            ('2020-05-30', 'Basketball'),
            ('2020-06-01', 'Bible'),
            ('2020-06-02', 'Mask'),
            ('2020-05-30', 'T-Shirt');
            """
            , new Row[] {
                ("2020-05-30", 3, "Basketball,Headphone,T-Shirt"),
                ("2020-06-01", 2, "Bible,Pencil"),
                ("2020-06-02", 1, "Mask"),
            }
        ],
        [
            """
            insert into Activities (sell_date, product) values 
            ('2020-07-16','Longcoat'),
            ('2020-06-11','Cap'),
            ('2020-07-27','Hat'),
            ('2020-07-17','Diaper'),
            ('2020-06-04','Hat'),
            ('2020-06-25','Socks'),
            ('2020-07-23','Hat'),
            ('2020-06-13','Handbag'),
            ('2020-06-24','Mortarboard'),
            ('2020-07-30','Mascara'),
            ('2020-07-03','Handbag'),
            ('2020-06-05','Cap'),
            ('2020-07-25','Mortarboard'),
            ('2020-07-18','Cap'),
            ('2020-07-12','Bronzer'),
            ('2020-06-10','Cap'),
            ('2020-07-24','Longcoat'),
            ('2020-06-14','Mascara'),
            ('2020-07-02','Mortarboard'),
            ('2020-07-23','Handbag'),
            ('2020-07-15','Bronzer'),
            ('2020-06-22','Diaper'),
            ('2020-06-09','Handbag'),
            ('2020-07-30','Flip-flops'),
            ('2020-06-24','Socks'),
            ('2020-06-18','Socks'),
            ('2020-06-09','Boots'),
            ('2020-06-22','Mortarboard'),
            ('2020-07-20','Cap'),
            ('2020-06-03','Flip-flops'),
            ('2020-07-05','Bronzer'),
            ('2020-07-05','Mortarboard'),
            ('2020-06-28','Mortarboard'),
            ('2020-07-13','Hat'),
            ('2020-07-16','Mortarboard'),
            ('2020-07-02','Socks'),
            ('2020-07-30','Mascara'),
            ('2020-07-23','Mortarboard'),
            ('2020-07-06','Boots'),
            ('2020-07-25','Diaper'),
            ('2020-06-09','Jacket'),
            ('2020-06-29','Boots'),
            ('2020-07-29','Mortarboard'),
            ('2020-07-27','Cap'),
            ('2020-07-09','Flip-flops'),
            ('2020-06-20','Mascara'),
            ('2020-07-18','Mortarboard'),
            ('2020-07-31','Bronzer'),
            ('2020-06-20','Mascara');
            """,
            new Row[] {
                ("2020-06-03",1,"Flip-flops"),            
                ("2020-06-04",1,"Hat"),                   
                ("2020-06-05",1,"Cap"),                   
                ("2020-06-09",3,"Boots,Handbag,Jacket"),  
                ("2020-06-10",1,"Cap"),                   
                ("2020-06-11",1,"Cap"),                   
                ("2020-06-13",1,"Handbag"),               
                ("2020-06-14",1,"Mascara"),               
                ("2020-06-18",1,"Socks"),                 
                ("2020-06-20",1,"Mascara"),               
                ("2020-06-22",2,"Diaper,Mortarboard"),    
                ("2020-06-24",2,"Mortarboard,Socks"),     
                ("2020-06-25",1,"Socks"),                 
                ("2020-06-28",1,"Mortarboard"),           
                ("2020-06-29",1,"Boots"),                 
                ("2020-07-02",2,"Mortarboard,Socks"),     
                ("2020-07-03",1,"Handbag"),               
                ("2020-07-05",2,"Bronzer,Mortarboard"),
            }
        ]
    ];
}
public class Q1484_GroupSoldProductsByDateTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Activities (sell_date date, product varchar(20));
    """;

    [Theory]
    [ClassData(typeof(Q1484_GroupSoldProductsByDateTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1484_GroupSoldProductsByDate();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["sell_date", "num_sold", "products"]);
        foreach(var (sell_date, num_sold, products) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(sell_date, reader.GetDateTime(0).ToString("yyyy-MM-dd"));
            Assert.Equal(num_sold, reader.GetInt32(1));
            Assert.Equal(products, reader.GetString(2));
        }
    }
}