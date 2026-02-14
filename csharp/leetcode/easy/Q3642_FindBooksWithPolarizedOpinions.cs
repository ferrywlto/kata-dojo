using Row = (int book_id, string title, string author, string genre, int pages, int rating_spread, float polarization_score);
public class Q3642_FindBooksWithPolarizedOpinions(ITestOutputHelper output) : SqlTest(output)
{
    public static string Query =>
    """
    SELECT r.book_id,
    b.title,
    b.author,
    b.genre,
    b.pages,
    MAX(session_rating) - MIN(session_rating) as 'rating_spread',
    ROUND(SUM(CASE WHEN session_rating <> 3 THEN 1 ELSE 0 END) * 1.0 / count(session_id), 2) as 'polarization_score'
    FROM reading_sessions r
    LEFT JOIN books b ON r.book_id = b.book_id
    WHERE r.book_id in
    (
        SELECT 
            book_id
        FROM reading_sessions
        GROUP BY book_id
        HAVING
            COUNT(session_id) >= 5 AND
            SUM(CASE WHEN session_rating >= 4 THEN 1 ELSE 0 END) >= 1 AND
            SUM(CASE WHEN session_rating <= 2 THEN 1 ELSE 0 END) >= 1    
    )
    GROUP BY r.book_id
    HAVING ROUND(SUM(CASE WHEN session_rating <> 3 THEN 1 ELSE 0 END) * 1.0 / count(session_id), 2) >= 0.6
    ORDER BY polarization_score DESC, b.title DESC
    """;

    public static TheoryData<string, Row[]> TestData => new()
    {
        {
            """
            insert into books (book_id, title, author, genre, pages) values
            (1, 'The Great Gatsby', 'F. Scott', 'Fiction', 180), 
            (2, 'To Kill a Mockingbird', 'Harper Lee', 'Fiction', 281), 
            (3, '1984', 'George Orwell', 'Dystopian', 328), 
            (4, 'Pride and Prejudice', 'Jane Austen', 'Romance', 432), 
            (5, 'The Catcher in the Rye', 'J.D. Salinger', 'Fiction', 277);

            insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values
            (1, 1, 'Alice', 50, 5), 
            (2, 1, 'Bob', 60, 1), 
            (3, 1, 'Carol', 40, 4), 
            (4, 1, 'David', 30, 2), 
            (5, 1, 'Emma', 45, 5), 
            (6, 2, 'Frank', 80, 4), 
            (7, 2, 'Grace', 70, 4), 
            (8, 2, 'Henry', 90, 5), 
            (9, 2, 'Ivy', 60, 4), 
            (10, 2, 'Jack', 75, 4), 
            (11, 3, 'Kate', 100, 2), 
            (12, 3, 'Liam', 120, 1), 
            (13, 3, 'Mia', 80, 2), 
            (14, 3, 'Noah', 90, 1), 
            (15, 3, 'Olivia', 110, 4), 
            (16, 3, 'Paul', 95, 5), 
            (17, 4, 'Quinn', 150, 3), 
            (18, 4, 'Ruby', 140, 3), 
            (19, 5, 'Sam', 80, 1), 
            (20, 5, 'Tara', 70, 2);
            """,
            [
                (1, "The Great Gatsby", "F. Scott", "Fiction", 180, 4, 1.00f),
                (3, "1984", "George Orwell", "Dystopian", 328, 4, 1.00f)
            ]
        },
        {
            """
            INSERT INTO books (book_id, title, author, genre, pages) VALUES
            (1, 'Digital Dreams', 'John Smith', 'Comedy', 290),
            (2, 'The Golden Path', 'Lisa Taylor', 'Romance', 527),
            (3, 'Thunder Mountain', 'Betty Wright', 'Adventure', 194),
            (4, 'The Wild Hunt', 'Patricia Harris', 'Fiction', 165),
            (5, 'Lost Horizon', 'Robert Anderson', 'Science Fiction', 408),
            (6, 'Starlight Express', 'John Smith', 'Adventure', 251),
            (7, 'The Glass Castle', 'Mark Allen', 'Comedy', 429),
            (8, 'The Empty Throne', 'Lisa Taylor', 'Biography', 451),
            (9, 'Broken Chains', 'John Smith', 'Romance', 507),
            (10, 'The Forgotten City', 'James Martin', 'Romance', 260),
            (11, 'The Iron Tower', 'William Jones', 'Mystery', 197),
            (12, 'Dancing Shadows', 'Sarah Wilson', 'Thriller', 583),
            (13, 'Rising Storm', 'Susan Hall', 'Fantasy', 563),
            (14, 'Mysteries of Time', 'Betty Wright', 'Biography', 424),
            (15, 'Crystal Palace', 'Mary Garcia', 'Horror', 466),
            (16, 'Desert Rose', 'Elizabeth White', 'Drama', 248),
            (17, 'Midnight Sun', 'Michael Brown', 'Science Fiction', 593),
            (18, 'Whispers in the Dark', 'Mark Allen', 'Thriller', 233);

            INSERT INTO reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) VALUES
            (1, 1, 'David', 78, 5),
            (2, 1, 'Carol', 100, 2),
            (3, 1, 'Zach', 88, 4),
            (4, 1, 'Emma', 74, 4),
            (5, 1, 'Uma', 74, 2),
            (6, 1, 'Felix', 121, 4),
            (7, 1, 'Daniel', 56, 1),
            (8, 2, 'Brian', 36, 2),
            (9, 2, 'Yolanda', 117, 5),
            (10, 2, 'Daniel', 84, 5),
            (11, 2, 'Alice', 49, 2),
            (12, 2, 'Ruby', 107, 2),
            (13, 2, 'Henry', 95, 5),
            (14, 2, 'Kate', 136, 4),
            (15, 3, 'Felix', 24, 2),
            (16, 3, 'Henry', 112, 3),
            (17, 3, 'Tara', 81, 2),
            (18, 3, 'David', 81, 4),
            (19, 3, 'Frank', 41, 2),
            (20, 4, 'Victor', 25, 2),
            (21, 4, 'Olivia', 76, 2),
            (22, 4, 'Alice', 38, 3),
            (23, 4, 'David', 78, 4),
            (24, 4, 'Emma', 28, 4),
            (25, 4, 'Paul', 91, 2),
            (26, 4, 'Felix', 74, 4),
            (27, 4, 'Ivy', 141, 5),
            (28, 4, 'Eva', 124, 5),
            (29, 4, 'Mia', 44, 2),
            (30, 5, 'Grace', 83, 1),
            (31, 5, 'Mia', 68, 2),
            (32, 5, 'Claire', 55, 5),
            (33, 5, 'Brian', 66, 1),
            (34, 5, 'Ruby', 138, 5),
            (35, 6, 'David', 62, 1),
            (36, 6, 'Yolanda', 20, 1),
            (37, 6, 'Quinn', 136, 4),
            (38, 6, 'Sam', 128, 2),
            (39, 6, 'Felix', 59, 2),
            (40, 6, 'Mia', 95, 1),
            (41, 7, 'David', 150, 4),
            (42, 7, 'Frank', 67, 5),
            (43, 7, 'Emma', 37, 4),
            (44, 7, 'Paul', 123, 4),
            (45, 7, 'Henry', 83, 5),
            (46, 7, 'Carol', 40, 4),
            (47, 8, 'Tara', 137, 2),
            (48, 8, 'Uma', 38, 2),
            (49, 8, 'Alice', 137, 1),
            (50, 8, 'Grace', 38, 2),
            (51, 8, 'Noah', 149, 1),
            (52, 8, 'Quinn', 53, 2),
            (53, 8, 'Wendy', 37, 2),
            (54, 8, 'Paul', 114, 1),
            (55, 9, 'Henry', 47, 5),
            (56, 9, 'Jack', 89, 5),
            (57, 9, 'Sam', 73, 4),
            (58, 9, 'Victor', 72, 5),
            (59, 9, 'Quinn', 149, 4),
            (60, 9, 'Felix', 84, 4),
            (61, 9, 'David', 43, 5),
            (62, 10, 'Carol', 20, 3),
            (63, 10, 'Victor', 53, 3),
            (64, 10, 'Quinn', 61, 3),
            (65, 10, 'Claire', 129, 3),
            (66, 10, 'Alice', 48, 3),
            (67, 10, 'Emma', 58, 3),
            (68, 10, 'Xavier', 57, 3),
            (69, 10, 'Brian', 52, 3),
            (70, 11, 'Tara', 113, 1),
            (71, 12, 'Noah', 83, 1),
            (72, 12, 'Wendy', 124, 5),
            (73, 12, 'Jack', 80, 2),
            (74, 13, 'Anna', 26, 2),
            (75, 13, 'Victor', 125, 2),
            (76, 14, 'Kate', 47, 4),
            (77, 14, 'Carol', 140, 2),
            (78, 14, 'Mia', 137, 3),
            (79, 15, 'Olivia', 77, 1),
            (80, 15, 'Mia', 122, 3),
            (81, 15, 'Ruby', 37, 3),
            (82, 15, 'Wendy', 150, 4),
            (83, 15, 'Victor', 27, 1),
            (84, 16, 'Liam', 87, 1),
            (85, 16, 'Grace', 131, 3),
            (86, 16, 'Uma', 131, 5),
            (87, 16, 'Henry', 118, 5),
            (88, 16, 'Mia', 85, 1),
            (89, 17, 'Brian', 20, 5),
            (90, 17, 'Mia', 113, 4),
            (91, 17, 'Emma', 104, 5),
            (92, 17, 'Uma', 51, 3),
            (93, 17, 'Tara', 124, 3),
            (94, 17, 'Zach', 95, 5),
            (95, 17, 'Ivy', 69, 4),
            (96, 17, 'Yolanda', 64, 5),
            (97, 18, 'Tara', 123, 5),
            (98, 18, 'Alice', 97, 3),
            (99, 18, 'Noah', 130, 5),
            (100, 18, 'Uma', 139, 4),
            (101, 18, 'Claire', 74, 5),
            (102, 18, 'Eva', 63, 1),
            (103, 18, 'Sam', 105, 1);          
            """,
            [
                (2, "The Golden Path", "Lisa Taylor", "Romance", 527, 3, 1.00f),
                (6, "Starlight Express", "John Smith", "Adventure", 251, 3, 1.00f),
                (5, "Lost Horizon", "Robert Anderson", "Science Fiction", 408, 4, 1.00f),
                (1, "Digital Dreams", "John Smith", "Comedy", 290, 4, 1.00f),
                (4, "The Wild Hunt", "Patricia Harris", "Fiction", 165, 3, 0.90f),
                (18, "Whispers in the Dark", "Mark Allen", "Thriller", 233, 4, 0.86f),
                (3, "Thunder Mountain", "Betty Wright", "Adventure", 194, 2, 0.8f),
                (16, "Desert Rose", "Elizabeth White", "Drama", 248, 4, 0.8f),
                (15, "Crystal Palace", "Mary Garcia", "Horror", 466, 3, 0.6f)
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
    );
    CREATE TABLE reading_sessions (
        session_id INT,
        book_id INT,
        reader_name VARCHAR(255),
        pages_read INT,
        session_rating INT
    );
    """;

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var reader = ExecuteQuery(Query);

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
            Assert.Equal(Math.Round(polarization_score, 2), Math.Round(reader.GetFloat(6), 2));
        }
    }
}
