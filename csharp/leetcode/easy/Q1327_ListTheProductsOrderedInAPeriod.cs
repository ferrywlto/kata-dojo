using Row = (string product_name, int unit);
class Q1327_ListTheProductsOrderedInAPeriod : SqlQuestion
{
    public override string Query =>
    """
    select product_name, sum(unit) as unit from Orders o 
    left join Products p
    on o.product_id = p.product_id
    where order_date between '2020-02-01' and '2020-02-29'
    group by o.product_id
    having sum(unit) >= 100;
    """;
}
class Q1327_ListTheProductsOrderedInAPeriodTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            """
            insert into Products (product_id, product_name, product_category) values 
            ('1', 'Leetcode Solutions', 'Book'),
            ('2', 'Jewels of Stringology', 'Book'),
            ('3', 'HP', 'Laptop'),
            ('4', 'Lenovo', 'Laptop'),
            ('5', 'Leetcode Kit', 'T-shirt');
            
            insert into Orders (product_id, order_date, unit) values 
            ('1', '2020-02-05', '60'),
            ('1', '2020-02-10', '70'),
            ('2', '2020-01-18', '30'),
            ('2', '2020-02-11', '80'),
            ('3', '2020-02-17', '2'),
            ('3', '2020-02-24', '3'),
            ('4', '2020-03-01', '20'),
            ('4', '2020-03-04', '30'),
            ('4', '2020-03-04', '60'),
            ('5', '2020-02-25', '50'),
            ('5', '2020-02-27', '50'),
            ('5', '2020-03-01', '50');
            """,
            new Row[] 
            {
                new("Leetcode Solutions", 130), 
                new("Leetcode Kit", 100) 
            }
        ]
    ];
}
public class Q1327_ListTheProductsOrderedInAPeriodTests: SqlTest
{
    protected override string TestSchema => 
    """
    Create table If Not Exists Products (product_id int, product_name varchar(40), product_category varchar(40));
    Create table If Not Exists Orders (product_id int, order_date date, unit int);
    """;

    [Theory]
    [ClassData(typeof(Q1327_ListTheProductsOrderedInAPeriodTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1327_ListTheProductsOrderedInAPeriod();
        var reader = ExecuteQuery(sut.Query);
        AssertResultSchema(reader, ["product_name", "unit"]);
        foreach(var row in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(row.product_name, reader.GetString(0));
            Assert.Equal(row.unit, reader.GetInt32(1));
        }
    }
}
