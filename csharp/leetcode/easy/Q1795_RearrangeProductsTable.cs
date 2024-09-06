using Row = (int product_id, string store, int price);
class Q1795_RearrangeProductsTable : SqlQuestion
{
    public override string Query =>
    """
    select p1.product_id, 'store1' as 'store', store1 as 'price' from Products p1 where store1 is not null
    union 
    select p2.product_id, 'store2' as 'store', store2 as 'price' from Products p2 where store2 is not null
    union 
    select p3.product_id, 'store3' as 'store', store3 as 'price' from Products p3 where store3 is not null;
    """;
}
class Q1795_RearrangeProductsTableTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            insert into Products (product_id, store1, store2, store3) values ('0', '95', '100', '105');
            insert into Products (product_id, store1, store2, store3) values ('1', '70', null, '80');
            """,
            new Row[]
            {
                (0, "store1", 95),
                (0, "store2", 100),
                (0, "store3", 105),
                (1, "store1", 70),
                (1, "store3", 80),
            }
        ]
    ];
}
public class Q1795_RearrangeProductsTableTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    Create table If Not Exists Products (product_id int, store1 int, store2 int, store3 int);
    """;
    [Theory]
    [ClassData(typeof(Q1795_RearrangeProductsTableTestData))]
    public void OfficialTestCases(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var sut = new Q1795_RearrangeProductsTable();
        var reader = ExecuteQuery(sut.Query, true);
        AssertResultSchema(reader, ["product_id", "store", "price"]);
        foreach (var r in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(r.product_id, reader.GetInt32(0));
            Assert.Equal(r.store, reader.GetString(1));
            Assert.Equal(r.price, reader.GetInt32(2));
        }

    }
}