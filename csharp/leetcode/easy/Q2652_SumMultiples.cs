public class Q2652_SumMultiples
{
    public int SumOfMultiples(int n)
    {
        return 0;
    }
    public static TheoryData<int, int> TestData => new() {
        {7, 21},
        {10, 40},
        {9, 30},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = SumOfMultiples(input);
        Assert.Equal(expected, actual);
    }
}