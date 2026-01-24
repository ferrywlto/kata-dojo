using Row = (int user_id, string dominant_reaction, double reaction_ratio);
public class Q3808_FindEmotionallyConsistentUsers(ITestOutputHelper output) : SqlTest(output)
{
    public string Query => 

    """
    select * from
    (
        select 
            u.user_id, 
            r.reaction as dominant_reaction, 
            CAST(r.r_count/CAST(u.content_count as DOUBLE) as DECIMAL(10, 2)) as reaction_ratio  
        from 
        (
            SELECT user_id, count(content_id) as content_count From reactions
            GROUP BY user_id
            HAVING count(distinct content_id) >= 5
        ) u, 
        (
            SELECT user_id, reaction, count(reaction) as r_count From reactions
            GROUP BY user_id, reaction
        ) r
        where u.user_id = r.user_id
    ) x
    where reaction_ratio > 0.6
    order by reaction_ratio desc, user_id asc;
    """;

    protected override string TestSchema => 
    """
    CREATE TABLE reactions (
        user_id INT,
        content_id INT,
        reaction VARCHAR(255)
    );
    """;

    public static TheoryData<string, Row[]> TestData => new ()
    {
        {
            """
            insert into reactions (user_id, content_id, reaction) values
                ('1', '101', 'like'),
                ('1', '102', 'like'),
                ('1', '103', 'like'),
                ('1', '104', 'wow'),
                ('1', '105', 'like'),
                ('2', '201', 'like'),
                ('2', '202', 'wow'),
                ('2', '203', 'sad'),
                ('2', '204', 'like'),
                ('2', '205', 'wow'),
                ('3', '301', 'love'),
                ('3', '302', 'love'),
                ('3', '303', 'love'),
                ('3', '304', 'love'),
                ('3', '305', 'love');
            """,
            [
                new Row(3, "love", 1.00),
                new Row(1, "like", 0.80)
            ]
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string dataSql , Row[] expected)
    {
        ArrangeTestData(dataSql);
        var reader = ExecuteQuery(Query, true);
        AssertResultSchema(reader, ["user_id", "dominant_reaction", "reaction_ratio"]);

        foreach(var (user_id, dominant_reaction, reaction_ratio) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(user_id, reader.GetInt32(0));
            Assert.Equal(dominant_reaction, reader.GetString(1));
            Assert.Equal(reaction_ratio, reader.GetDouble(2));
        }
    }
}
