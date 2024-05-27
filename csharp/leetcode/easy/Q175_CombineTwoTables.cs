class Q175_CombineTwoTables : SqlQuestion
{
    public override string Query =>
    """
    SELECT Person.FirstName, Person.LastName, Address.City, Address.State
    FROM Person
    LEFT JOIN Address
    ON Person.PersonId = Address.PersonId;
    """;
}

class Q175_CombineTwoTablesTestData : TestData
{
    protected override List<object[]> Data =>
    [[
        """
        INSERT INTO Person VALUES
        (1, 'Wang', 'Allen'),
        (2, 'Alice', 'Bob');

        INSERT INTO Address VALUES
        (1, 2, 'New York City', 'New York'),
        (2, 3, 'Leetcode', 'California');
        """
    ]];
}

public class Q175_CombineTwoTablesTests(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Person (personId INT, lastName VARCHAR, firstName VARCHAR);
    CREATE TABLE IF NOT EXISTS Address (addressId INT, personId INT, city VARCHAR, state VARCHAR);
    """;

    [Theory]
    [ClassData(typeof(Q175_CombineTwoTablesTestData))]
    public override void OfficialTestCases(string input)
    {
        ArrangeTestData(input);

        var sut = new Q175_CombineTwoTables();
        var reader = ExecuteQuery(sut.Query);

        Assert.True(reader.HasRows);

        Assert.True(reader.Read());
        Assert.Equal("Allen", reader.GetString(0));
        Assert.Equal("Wang", reader.GetString(1));
        Assert.True(reader.IsDBNull(2));
        Assert.True(reader.IsDBNull(3));

        Assert.True(reader.Read());
        Assert.Equal("Bob", reader.GetString(0));
        Assert.Equal("Alice", reader.GetString(1));
        Assert.Equal("New York City", reader.GetString(2));
        Assert.Equal("New York", reader.GetString(3));

        Assert.False(reader.Read());
    }
}