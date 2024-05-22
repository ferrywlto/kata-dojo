
class Q999_AvailableCapturesForRook
{
    public int NumRookCaptures(char[][] board) 
    {
        return 0;   
    }
}

class Q999_AvailableCapturesForRookTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            new char[][]
            {
                ['.','.','.','.','.','.','.','.'],
                ['.','.','.','p','.','.','.','.'],
                ['.','.','.','R','.','.','.','p'],
                ['.','.','.','.','.','.','.','.'],
                ['.','.','.','.','.','.','.','.'],
                ['.','.','.','p','.','.','.','.'],
                ['.','.','.','.','.','.','.','.'],
                ['.','.','.','.','.','.','.','.']
            }, 3
        ],
        [
            new char[][]
            {
                ['.','.','.','.','.','.','.','.'],
                ['.','p','p','p','p','p','.','.'],
                ['.','p','p','B','p','p','.','.'],
                ['.','p','B','R','B','p','.','.'],
                ['.','p','p','B','p','p','.','.'],
                ['.','p','p','p','p','p','.','.'],
                ['.','.','.','.','.','.','.','.'],
                ['.','.','.','.','.','.','.','.']
            }, 0
        ],
        [
            new char[][]
            {
                ['.','.','.','.','.','.','.','.'],
                ['.','.','.','p','.','.','.','.'],
                ['.','.','.','p','.','.','.','.'],
                ['p','p','.','R','.','p','B','.'],
                ['.','.','.','.','.','.','.','.'],
                ['.','.','.','B','.','.','.','.'],
                ['.','.','.','p','.','.','.','.'],
                ['.','.','.','.','.','.','.','.']
            }, 3
        ],
    ];
}

public class Q999_AvailableCapturesForRookTests
{
    [Theory]
    [ClassData(typeof(Q999_AvailableCapturesForRookTestData))]
    public void OfficialTestCases(char[][] input, int expected)
    {
        var sut = new Q999_AvailableCapturesForRook();
        var actual = sut.NumRookCaptures(input);
        Assert.Equal(expected, actual);
    }
}