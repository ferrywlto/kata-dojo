using System.Text;
using Microsoft.Data.Sqlite;
using Xunit.Sdk;

namespace dojo.leetcode;

public abstract class SqlTest : BaseTest, IDisposable
{
    protected readonly SqliteConnection connection;
    public SqlTest(ITestOutputHelper output) : base(output)
    {
        connection = new SqliteConnection("Filename=:memory:");
        connection.Open();

        CreateTestDatabase();
    }

    const int ColumnWidth = 10;
    public abstract void OfficialTestCases(string testDataSql);
    protected abstract string TestSchema { get; }
    protected virtual string FormatOutput(string input) => $" {(input.Length <= ColumnWidth ? input.PadRight(ColumnWidth) : input)} |";
    protected bool IsDatabaseConnectionOpened() => connection.State == System.Data.ConnectionState.Open;

    protected int ExecuteCommand(string Sql) => CreateCommand(Sql).ExecuteNonQuery();

    protected void ArrangeTestData(string Sql) => ExecuteCommand(Sql);

    protected SqliteDataReader ExecuteQuery(string Sql, bool debug = false)
    {
        if (debug)
        {
            DebugReader(CreateCommand(Sql).ExecuteReader());
        }
        return CreateCommand(Sql).ExecuteReader();
    }


    protected void DebugReader(SqliteDataReader reader)
    {
        if (!reader.HasRows) return;

        var stringBuilder = new StringBuilder("|");
        for (var i = 0; i < reader.FieldCount; i++)
            stringBuilder.Append(FormatOutput(reader.GetName(i)));

        Output!.WriteLine(stringBuilder.ToString());

        while (reader.Read())
        {
            stringBuilder.Clear();
            stringBuilder.Append('|');
            for (var i = 0; i < reader.FieldCount; i++)
            {
                var colValue = reader.IsDBNull(i) ? "NULL" : reader.GetString(i);
                stringBuilder.Append(FormatOutput(colValue));
            }
            Output.WriteLine(stringBuilder.ToString());
        }
        reader.Close();
    }

    private void CreateTestDatabase()
    {
        if (!IsDatabaseConnectionOpened()) throw new Exception("Database connection is not opened.");

        var command = connection.CreateCommand();
        command.CommandType = System.Data.CommandType.Text;

        if (string.IsNullOrEmpty(TestSchema)) throw new Exception("Test schema is empty.");

        command.CommandText = TestSchema;
        command.ExecuteNonQuery();
    }

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

public class TestDatabaseTestClass(ITestOutputHelper output) : SqlTest(output)
{
    protected override string TestSchema => string.Empty;

    public override void OfficialTestCases(string testDataSql)
    {
        throw new NotImplementedException();
    }
}

public class TestsOfDatabaseTest
{
    [Fact]
    public void InitializeTestData_ShouldThrowExceptionByDefault()
    {
        var exception = Record.Exception(() =>
        {
            var sut = new TestDatabaseTestClass(new TestOutputHelper());
        });
        Assert.NotNull(exception);
        Assert.StartsWith("Test schema is empty", exception.Message);
    }
}