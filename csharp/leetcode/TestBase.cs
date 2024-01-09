using Microsoft.Data.Sqlite;
using Xunit.Sdk;

namespace dojo.leetcode;

public class TestBase(ITestOutputHelper output) 
{
    protected readonly ITestOutputHelper output = output;    
}


public class DatabaseTest : TestBase
{
    protected readonly SqliteConnection connection;
    public DatabaseTest(ITestOutputHelper output) : base(output) 
    {
        connection = new SqliteConnection("Filename=:memory:");
        connection.Open();

        InitializeTestData();
    }

    protected bool IsDatabaseConnectionOpened() => connection.State == System.Data.ConnectionState.Open;
    protected void InitializeTestData()
    {
        if (!IsDatabaseConnectionOpened()) throw new Exception("Database connection is not opened.");

        var command = connection.CreateCommand();
        command.CommandType = System.Data.CommandType.Text;
        
        var testSchema = GetTestSchema();
        if (string.IsNullOrEmpty(testSchema)) throw new Exception("Test schema is empty.");

        command.CommandText = testSchema;
        command.ExecuteNonQuery();
    }

    protected virtual string GetTestSchema() => string.Empty;

    protected void InputTestData(string Sql) => CreateCommand(Sql).ExecuteNonQuery();

    protected SqliteDataReader Execute(string Sql) => CreateCommand(Sql).ExecuteReader();


    private SqliteCommand CreateCommand(string Sql) 
    {
        var command = connection.CreateCommand();
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = Sql;
        return command;
    }

    ~DatabaseTest() 
    {
        connection.Dispose();
    }
}


public class TestsOfDatabaseTest
{
    [Fact]
    public void InitializeTestData_ShouldThrowExceptionByDefault() 
    {
        var exception = Record.Exception( () =>
        {
            var sut = new DatabaseTest(new TestOutputHelper());
        });
        Assert.NotNull(exception);
        Assert.StartsWith("Test schema is empty", exception.Message);
    }
}

public class Q175_CombineTwoTablesTestData : TestDataBase 
{
    protected override List<object[]> Data() => 
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
    protected override string GetTestSchema() =>
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
        var actual = Execute(sut.SQL());
        
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
    public string SQL() => 
    """
    SELECT Person.FirstName, Person.LastName, Address.City, Address.State
    FROM Person
    LEFT JOIN Address
    ON Person.PersonId = Address.PersonId;
    """;
}