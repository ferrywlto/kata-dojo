
using System.Text;
using dojo.leetcode;
using Microsoft.Data.Sqlite;


public class Q183_CustomersWhoNeverOrderTestData : TestDataBase
{
    protected override List<object[]> Data =>
    [
        [
            """
            INSERT INTO Customers VALUES (1, 'Joe');
            INSERT INTO Customers VALUES (2, 'Henry');
            INSERT INTO Customers VALUES (3, 'Sam');
            INSERT INTO Customers VALUES (4, 'Max');
            INSERT INTO Orders VALUES (1, 3);
            INSERT INTO Orders VALUES (2, 1);
            """
        ],
    ];
}

public class Q183_CustomersWhoNeverOrderTests(ITestOutputHelper output) : DatabaseTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Customers (id INT, name VARCHAR(255));
    CREATE TABLE IF NOT EXISTS Orders (id INT, customerId VARCHAR(255));
    """;

    [Theory]
    [ClassData(typeof(Q183_CustomersWhoNeverOrderTestData))]
    public void OfficialTestCases(string input)
    {
        InputTestData(input);

        var sut = new Q183_CustomersWhoNeverOrder();
        
        var reader = ExecuteQuery(sut.Query);

        Assert.True(reader.HasRows);
        Assert.Equal(1, reader.FieldCount);
        Assert.Equal("Customers", reader.GetName(0));

        Assert.True(reader.Read());
        Assert.Equal("Henry", reader.GetString(0));

        Assert.True(reader.Read());
        Assert.Equal("Max", reader.GetString(0));
    }
}

public class Q183_CustomersWhoNeverOrder
{
    public string Query =>
    """
    SELECT name as Customers FROM Customers WHERE id NOT IN (Select customerId from Orders) 
    """;
}