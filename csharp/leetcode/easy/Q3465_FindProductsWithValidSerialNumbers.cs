using Row = (int product_id, string product_name, string description);
public class Q3465_FindProductsWithValidSerialNumbers(ITestOutputHelper output) : SqlTest(output)
{
    public string Query =>
    """
    Select 1;
    """;

    public static TheoryData<string, Row[]> TestData => new()
    {
        {
            """
            insert into products (product_id, product_name, description) values
            ('1', 'Widget A', 'This is a sample product with SN1234-5678')
            ('2', 'Widget B', 'A product with serial SN9876-1234 in the description')
            ('3', 'Widget C', 'Product SN1234-56789 is available now')
            ('4', 'Widget D', 'No serial number here')
            ('5', 'Widget E', 'Check out SN4321-8765 in this description');
            """,
            new Row[]
            {
                (1, "Widget A", "This is a sample product with SN1234-5678"),
                (2, "Widget B", "A product with serial SN9876-1234 in the description"),
                (5, "Widget E", "Check out SN4321-8765 in this description"),
            }
        }
    };
    protected override string TestSchema =>
    """
    CREATE TABLE If not exists products (
        product_id INT,
        product_name VARCHAR(255),
        description VARCHAR(255)
    )
    """;
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var reader = ExecuteQuery(Query);
        AssertResultSchema(reader, ["product_id", "product_name", "description"]);
        foreach (var (product_id, product_name, description) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(product_id, reader.GetInt32(0));
            Assert.Equal(product_name, reader.GetString(1));
            Assert.Equal(description, reader.GetString(1));
        }
    }
}
