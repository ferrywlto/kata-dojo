
using dojo.leetcode;


public class Q182_DuplicateEmailsTestData : TestDataBase
{
    protected override List<object[]> Data() =>
    [
        [
            """
            INSERT INTO Person VALUES (1, 'a@b.com');
            INSERT INTO Person VALUES (2, 'c@d.com');
            INSERT INTO Person VALUES (3, 'a@b.com');
            """
        ],
    ];
}

public class Q182_DuplicateEmailsTests(ITestOutputHelper output) : DatabaseTest(output)
{
    protected override string TestSchema =>
    """
    CREATE TABLE IF NOT EXISTS Person (id INT, email VARCHAR(255));
    """;

    [Theory]
    [ClassData(typeof(Q182_DuplicateEmailsTestData))]
    public void OfficialTestCases(string input)
    {
        InputTestData(input);

        var sut = new Q182_DuplicateEmails();
        
        var reader = Execute(sut.Query);

        Assert.True(reader.HasRows);
        Assert.Equal(1, reader.FieldCount);
        Assert.True(reader.Read());
        Assert.Equal("a@b.com", reader.GetString(0));
    }
    
}

public class Q182_DuplicateEmails
{
    public string Query =>
    """
    SELECT Email FROM Person GROUP BY Email HAVING COUNT(Email) > 1;
    """;
}