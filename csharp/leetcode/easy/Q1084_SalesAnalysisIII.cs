
using System.ComponentModel;
using Xunit;

class Q1084_SalesAnalysisIII : SqlQuestion
{
    public override string Query =>
    """
    SELECT DISTINCT * FROM
    (
        SELECT p.product_id, p.product_name 
        FROM Sales s LEFT JOIN Product p
        ON s.product_id = p.product_id
        WHERE sale_date >= '2019-01-01' and sale_date <= '2019-03-31'
    ) t1
    WHERE t1.product_id NOT IN
    (
        SELECT p.product_id
        FROM Sales s LEFT JOIN Product p
        ON s.product_id = p.product_id
        WHERE sale_date < '2019-01-01' OR sale_date > '2019-03-31'
    );
    """;
}
class Q1084_SalesAnalysisIIITestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            """
            insert into Product (product_id, product_name, unit_price) values 
            ('1', 'S8', '1000'),
            ('2', 'G4', '800'),
            ('3', 'iPhone', '1400');
            insert into Sales (seller_id, product_id, buyer_id, sale_date, quantity, price) values 
            ('1', '1', '1', '2019-01-21', '2', '2000'),
             ('1', '2', '2', '2019-02-17', '1', '800'),
             ('2', '2', '3', '2019-06-02', '1', '800'),
             ('3', '3', '4', '2019-05-13', '2', '2800');            
            """
        ]
    ];
}
[Trait("QuestionType", "SQL")]
public class Q1084_SalesAnalysisIIITests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema => 
    """
    Create table If Not Exists Product (product_id int, product_name varchar(10), unit_price int);
    Create table If Not Exists Sales (seller_id int, product_id int, buyer_id int, sale_date date, quantity int, price int);
    """;

    [Theory]
    [ClassData(typeof(Q1084_SalesAnalysisIIITestData))]
    public override void OfficialTestCases(string testDataSql)
    {
        ArrangeTestData(testDataSql);

        var sut = new Q1084_SalesAnalysisIII();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["product_id", "product_name"]);

        Assert.True(reader.Read());
        Assert.Equal(1, reader.GetInt32(0));
        Assert.Equal("S8", reader.GetString(1));
    }
}
