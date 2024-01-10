namespace dojo.leetcode;

public class Q175_CombineTwoTablesTestData : TestDataBase 
{
    protected override List<object[]> Data => 
    [
        [
            """
            INSERT INTO Person VALUES(1, 'Wang', 'Allen');
            INSERT INTO Person VALUES(2, 'Alice', 'Bob');
            INSERT INTO Address VALUES(1, 2, 'New York City', 'New York');
            INSERT INTO Address VALUES(2, 3, 'Leetcode', 'California');
            """
        ]
    ];
}

public class Q175_CombineTwoTablesTests(ITestOutputHelper output) : DatabaseTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Person (personId int, lastName varchar(255), firstName varchar(255));
    CREATE TABLE IF NOT EXISTS Address (addressId int, personId, city varchar(255), state varchar(255));
    """;

    [Theory]
    [ClassData(typeof(Q175_CombineTwoTablesTestData))]
    public void OfficialTestCases(string input)
    {
        InputTestData(input);

        var sut = new Q175_CombineTwoTables();
        var actual = Execute(sut.Query);
        
        Assert.True(actual.HasRows);
        
        Assert.True(actual.Read());
        Assert.Equal("Allen", actual.GetString(0));
        Assert.Equal("Wang", actual.GetString(1));
        Assert.True(actual.IsDBNull(2));
        Assert.True(actual.IsDBNull(3));

        Assert.True(actual.Read());
        Assert.Equal("Bob", actual.GetString(0));
        Assert.Equal("Alice", actual.GetString(1));
        Assert.Equal("New York City", actual.GetString(2));
        Assert.Equal("New York", actual.GetString(3));

        Assert.False(actual.Read());
    }
}

public class Q175_CombineTwoTables
{
    public string Query => 
    """
    SELECT Person.FirstName, Person.LastName, Address.City, Address.State
    FROM Person
    LEFT JOIN Address
    ON Person.PersonId = Address.PersonId;
    """;
}