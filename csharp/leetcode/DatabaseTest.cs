using Microsoft.Data.Sqlite;
using Xunit.Sdk;

namespace dojo.leetcode;

public class DatabaseTest : TestBase, IDisposable
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

    public void Dispose()
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