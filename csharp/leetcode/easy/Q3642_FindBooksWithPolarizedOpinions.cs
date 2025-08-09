using Row = (int book_id, string title, string author, string genre, int pages, int rating_spread, float polarization_score);
public class Q3642_FindBooksWithPolarizedOpinions(ITestOutputHelper output) : SqlTest(output)
{
    public static string Query =>
    """
    SELECT 1;
    """;

    public static TheoryData<string, Row[]> TestData => new()
    {
        {
            """
            insert into books (book_id, title, author, genre, pages) values
            ('1', 'The Great Gatsby', 'F. Scott', 'Fiction', '180'), 
            ('2', 'To Kill a Mockingbird', 'Harper Lee', 'Fiction', '281'), 
            ('3', '1984', 'George Orwell', 'Dystopian', '328'), 
            ('4', 'Pride and Prejudice', 'Jane Austen', 'Romance', '432'), 
            ('5', 'The Catcher in the Rye', 'J.D. Salinger', 'Fiction', '277');

            insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values
            ('1', '1', 'Alice', '50', '5'), 
            ('2', '1', 'Bob', '60', '1'), 
            ('3', '1', 'Carol', '40', '4'), 
            ('4', '1', 'David', '30', '2'), 
            ('5', '1', 'Emma', '45', '5'), 
            ('6', '2', 'Frank', '80', '4'), 
            ('7', '2', 'Grace', '70', '4'), 
            ('8', '2', 'Henry', '90', '5'), 
            ('9', '2', 'Ivy', '60', '4'), 
            ('10', '2', 'Jack', '75', '4'), 
            ('11', '3', 'Kate', '100', '2'), 
            ('12', '3', 'Liam', '120', '1'), 
            ('13', '3', 'Mia', '80', '2'), 
            ('14', '3', 'Noah', '90', '1'), 
            ('15', '3', 'Olivia', '110', '4'), 
            ('16', '3', 'Paul', '95', '5'), 
            ('17', '4', 'Quinn', '150', '3'), 
            ('18', '4', 'Ruby', '140', '3'), 
            ('19', '5', 'Sam', '80', '1'), 
            ('20', '5', 'Tara', '70', '2');
            """,
            [
                (1, "The Great Gatsby", "F. Scott", "Fiction", 180, 4, 1.00f),
                (3, "1984", "George Orwell", "Dystopian", 328, 4, 1.00f)
            ]
        }
    };

    protected override string TestSchema =>
    """
    CREATE TABLE books (
        book_id INT,
        title VARCHAR(255),
        author VARCHAR(255),
        genre VARCHAR(100),
        pages INT
    )
    CREATE TABLE reading_sessions (
        session_id INT,
        book_id INT,
        reader_name VARCHAR(255),
        pages_read INT,
        session_rating INT
    )
    """;

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var reader = ExecuteQuery(Query, true);

        AssertResultSchema(reader, ["book_id", "title", "author", "genre", "pages", "rating_spread", "polarization_score"]);
        foreach (var (book_id, title, author, genre, pages, rating_spread, polarization_score) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(book_id, reader.GetInt32(0));
            Assert.Equal(title, reader.GetString(1));
            Assert.Equal(author, reader.GetString(2));
            Assert.Equal(genre, reader.GetString(3));
            Assert.Equal(pages, reader.GetInt32(4));
            Assert.Equal(rating_spread, reader.GetInt32(5));
            Assert.Equal(polarization_score, reader.GetFloat(6));
        }
    }
}
