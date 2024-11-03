public class Q1925_CountSquareSumTriple
{
    // TC: O(n^3), n scale with size of n
    // SC: O(1), space used does not sacle with input 
    public int CountTriples(int n)
    {
        var result = 0;
        for (var i = n; i > 0; i--)
        {
            for (var j = 1; j < i; j++)
            {
                for (var k = 1; k < i; k++)
                {
                    if (k * k + j * j == i * i) result++;
                }
            }
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [5,2],
        [10,4],
        [250,330],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = CountTriples(input);
        Assert.Equal(expected, actual);
    }
}
