class Q1757_RecyclableAndLowFatProducts : SqlQuestion
{
    public override string Query =>
    """
    select product_id
    from Products
    where low_fats = 'Y'
    and recyclable = 'Y';
    """;
}
class Q1757_RecyclableAndLowFatProductsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Products (product_id, low_fats, recyclable) values 
            ('0', 'Y', 'N'),
            ('1', 'Y', 'Y'),
            ('2', 'N', 'Y'),
            ('3', 'Y', 'Y'),
            ('4', 'N', 'N');
            """,
            new int[]{ 1,3 }
        ]
    ];
}
public class Q1757_RecyclableAndLowFatProductsTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Products (
    product_id int, 
    low_fats CHAR(1) CHECK (low_fats IN ('Y', 'N')), 
    recyclable CHAR(1) CHECK (recyclable IN ('Y', 'N'))
    );
    """;

    [Theory]
    [ClassData(typeof(Q1757_RecyclableAndLowFatProductsTestData))]
    public void OfficialTestCases(string testDataSql, int[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1757_RecyclableAndLowFatProducts();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["product_id"]);
        foreach (var product_id in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(product_id, reader.GetInt32(0));
        }
    }
}