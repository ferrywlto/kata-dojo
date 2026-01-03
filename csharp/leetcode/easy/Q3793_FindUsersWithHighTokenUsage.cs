using Row = (int user_id, int prompt_count, double avg_tokens);

public class Q3793_FindUsersWithHighTokenUsage : SqlTest
{
    public string Query => "SELECT 1;";

    protected override string TestSchema =>
    """
    CREATE TABLE if not exists prompts (
        user_id INT,
        prompt VARCHAR(255),
        tokens INT
    );
    """;

    public static TheoryData<string, Row[]> TestData => new()
    {
        {
            """
            insert into prompts (user_id, prompt, tokens) values
            ('1', 'Write a blog outline', '120'),
            ('1', 'Generate SQL query', '80'),
            ('1', 'Summarize an article', '200'),
            ('2', 'Create resume bullet', '60'),
            ('2', 'Improve LinkedIn bio', '70'),
            ('3', 'Explain neural networks', '300'),
            ('3', 'Generate interview Q&A', '250'),
            ('3', 'Write cover letter', '180'),
            ('3', 'Optimize Python code', '220'),            
            """,
            [
                (3, 4, 237.5),
                (1,3,133.33)
            ]
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, Row[] expected)
    {
        ArrangeTestData(input);

        var reader = ExecuteQuery(Query, true);

        AssertResultSchema(reader, ["user_id", "prompt_count", "avg_tokens"]);

        foreach (var row in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(row.user_id, reader.GetInt32(0));
            Assert.Equal(row.prompt_count, reader.GetInt32(1));
            Assert.Equal(row.avg_tokens, Math.Round(reader.GetDouble(2),2));
        }
    }
}

