public class Q2614_PrimeInDiagonal
{
    public int DiagonalPrime(int[][] nums)
    {
        return 0;
    }
    public static TheoryData<int[][], int> TestData => new()
    {
        {
            new int[][]
            {
                [1,2,3],
                [5,6,7],
                [9,10,11],
            }, 11
        },
        {
            new int[][]
            {
                [1,2,3],
                [5,17,7],
                [9,11,10],
            }, 17
        },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = DiagonalPrime(input);
        Assert.Equal(expected, actual);
    }
}
