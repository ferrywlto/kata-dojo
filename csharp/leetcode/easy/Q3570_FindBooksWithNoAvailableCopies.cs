using Row = (int book_id, string title, string author, string genre, int publication_year, int current_borrowers);
public class Q3570_FindBooksWithNoAvailableCopies(ITestOutputHelper output) : SqlTest(output)
{
    public string Query =>
    """    
    SELECT lb.book_id, lb.title, lb.author, lb.genre, lb.publication_year, br.current_borrowers from library_books lb
    join 
    (
        select book_id, count(book_id) as current_borrowers from borrowing_records
        where borrow_date is not NULL AND return_date is NULL
        group by book_id 
    ) br on lb.book_id = br.book_id
    where lb.total_copies - br.current_borrowers = 0
    order by br.current_borrowers desc, title;
    """;
    /*
    */
    public static TheoryData<string, Row[]> TestData => new()
    {
        {
            """
            insert into library_books (book_id, title, author, genre, publication_year, total_copies) values 
            ('1', 'The Great Gatsby', 'F. Scott', 'Fiction', '1925', '3'),
            ('2', 'To Kill a Mockingbird', 'Harper Lee', 'Fiction', '1960', '3'),
            ('3', '1984', 'George Orwell', 'Dystopian', '1949', '1'),
            ('4', 'Pride and Prejudice', 'Jane Austen', 'Romance', '1813', '2'),
            ('5', 'The Catcher in the Rye', 'J.D. Salinger', 'Fiction', '1951', '1'),
            ('6', 'Brave New World', 'Aldous Huxley', 'Dystopian', '1932', '4');
            
            insert into borrowing_records (record_id, book_id, borrower_name, borrow_date, return_date) values 
            ('1', '1', 'Alice Smith', '2024-01-15', NULL),
            ('2', '1', 'Bob Johnson', '2024-01-20', NULL),
            ('3', '2', 'Carol White', '2024-01-10', '2024-01-25'),
            ('4', '3', 'David Brown', '2024-02-01', NULL),
            ('5', '4', 'Emma Wilson', '2024-01-05', NULL),
            ('6', '5', 'Frank Davis', '2024-01-18', '2024-02-10'),
            ('7', '1', 'Grace Miller', '2024-02-05', NULL),
            ('8', '6', 'Henry Taylor', '2024-01-12', NULL),
            ('9', '2', 'Ivan Clark', '2024-02-12', NULL),
            ('10', '2', 'Jane Adams', '2024-02-15', NULL);            
            """,
            new Row[] {
                new (1, "The Great Gatsby", "F. Scott"     , "Fiction"  , 1925, 3),
                new (3, "1984"            , "George Orwell", "Dystopian", 1949, 1)
            }
        }
    };

    protected override string TestSchema =>
    """
    CREATE TABLE library_books (
    book_id INT,
    title VARCHAR(255),
    author VARCHAR(255),
    genre VARCHAR(100),
    publication_year INT,
    total_copies INT
    );
    CREATE TABLE borrowing_records (
        record_id INT,
        book_id INT,
        borrower_name VARCHAR(255),
        borrow_date DATE,
        return_date DATE
    )
    """;

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string testDataSql, Row[] expected)
    {
        ArrangeTestData(testDataSql);
        var reader = ExecuteQuery(Query, true);
        AssertResultSchema(reader, ["book_id", "title", "author", "genre", "publication_year", "current_borrowers"]);
        foreach (var (book_id, title, author, genre, publication_year, current_borrowers) in expected)
        {
            Assert.True(reader.Read());
            Assert.Equal(book_id, reader.GetInt32(0));
            Assert.Equal(title, reader.GetString(1));
            Assert.Equal(author, reader.GetString(2));
            Assert.Equal(genre, reader.GetString(3));
            Assert.Equal(publication_year, reader.GetInt32(4));
            Assert.Equal(current_borrowers, reader.GetInt32(5));
        }
    }
}