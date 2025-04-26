using Row = (int sample_id, string dna_sequence, string species);

public class Q3475_DNAPatternRecognition(ITestOutputHelper output) : SqlTest(output)
{
    public string Query =>
    """
    SELECT 1;
    """;

    public static TheoryData<string, Row[]> TestData => new()
    {
        {
            """
            insert into Samples (sample_id, dna_sequence, species) values ('1', 'ATGCTAGCTAGCTAA', 'Human');
            insert into Samples (sample_id, dna_sequence, species) values ('2', 'GGGTCAATCATC', 'Human');
            insert into Samples (sample_id, dna_sequence, species) values ('3', 'ATATATCGTAGCTA', 'Human');
            insert into Samples (sample_id, dna_sequence, species) values ('4', 'ATGGGGTCATCATAA', 'Mouse');
            insert into Samples (sample_id, dna_sequence, species) values ('5', 'TCAGTCAGTCAG', 'Mouse');
            insert into Samples (sample_id, dna_sequence, species) values ('6', 'ATATCGCGCTAG', 'Zebrafish');
            insert into Samples (sample_id, dna_sequence, species) values ('7', 'CGTATGCGTCGTA', 'Zebrafish');
            """,
            [
                (1, "ATGCTAGCTAGCTAA", "Human"),
                (2, "GGGTCAATCATC", "Human"),
                (3, "ATATATCGTAGCTA", "Human"),
                (4, "ATGGGGTCATCATAA", "Mouse"),
                (5, "TCAGTCAGTCAG", "Mouse"),
                (6, "ATATCGCGCTAG", "Zebrafish"),
                (7, "CGTATGCGTCGTA", "Zebrafish"),
            ]
        }
    };

    protected override string TestSchema =>
    """
    CREATE TABLE if not exists Samples (
        sample_id INT,
        dna_sequence VARCHAR(255),
        species VARCHAR(100)
    )
    """;

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var reader = ExecuteQuery(Query);
        AssertResultSchema(reader, ["sample_id", "dna_sequence", "species"]);
        foreach (var (sample_id, dna_sequence, species) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(sample_id, reader.GetInt32(0));
            Assert.Equal(dna_sequence, reader.GetString(1));
            Assert.Equal(species, reader.GetString(2));
        }
    }
}
