public class Q1925_CountSquareSumTriple
{
    public int CountTriples(int n)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [5,2],
        [10,4],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = CountTriples(input);
        Assert.Equal(expected, actual);
    }
}
