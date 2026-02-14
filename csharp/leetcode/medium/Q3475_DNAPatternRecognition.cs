using Row = (int sample_id, string dna_sequence, string species, int has_start, int has_stop, int has_atat, int has_ggg);

public class Q3475_DNAPatternRecognition(ITestOutputHelper output) : SqlTest(output)
{
    // MySQL Dialect
    public string Query =>
    """
    SELECT sample_id, dna_sequence, species, 
    dna_sequence like 'ATG%' as has_start,
    dna_sequence like '%TAA' or 
    dna_sequence like '%TAG' or
    dna_sequence like '%TGA' as has_stop,
    dna_sequence like '%ATAT%' as has_atat,
    dna_sequence like '%GGG%' as has_ggg
    from Samples;
    """;
    // MSSQL Dialect
    /*
    SELECT sample_id, dna_sequence, species,
        CASE WHEN dna_sequence LIKE 'ATG%' THEN 1 ELSE 0 END AS has_start,
        CASE WHEN dna_sequence LIKE '%TAA' OR dna_sequence LIKE '%TAG' OR dna_sequence LIKE '%TGA' THEN 1 ELSE 0 END AS has_stop,
        CASE WHEN dna_sequence LIKE '%ATAT%' THEN 1 ELSE 0 END AS has_atat,
        CASE WHEN dna_sequence LIKE '%GGG%' THEN 1 ELSE 0 END AS has_ggg
    FROM Samples;    
    */
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
                (1, "ATGCTAGCTAGCTAA", "Human", 1, 1, 0, 0),
                (2, "GGGTCAATCATC", "Human", 0, 0, 0, 1),
                (3, "ATATATCGTAGCTA", "Human", 0, 0, 1, 0),
                (4, "ATGGGGTCATCATAA", "Mouse", 1, 1, 0, 1),
                (5, "TCAGTCAGTCAG", "Mouse", 0, 0, 0, 0),
                (6, "ATATCGCGCTAG", "Zebrafish", 0, 1, 1, 0),
                (7, "CGTATGCGTCGTA", "Zebrafish", 0, 0, 0, 0),
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
        var reader = ExecuteQuery(Query, true);
        AssertResultSchema(reader, ["sample_id", "dna_sequence", "species", "has_start", "has_stop", "has_atat", "has_egg"]);
        foreach (var (sample_id, dna_sequence, species, has_start, has_stop, has_atat, has_egg) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(sample_id, reader.GetInt32(0));
            Assert.Equal(dna_sequence, reader.GetString(1));
            Assert.Equal(species, reader.GetString(2));
            Assert.Equal(has_start, reader.GetInt32(3));
            Assert.Equal(has_stop, reader.GetInt32(4));
            Assert.Equal(has_atat, reader.GetInt32(5));
            Assert.Equal(has_egg, reader.GetInt32(6));
        }
    }
}
