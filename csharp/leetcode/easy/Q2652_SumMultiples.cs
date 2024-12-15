public class Q2652_SumMultiples
{
    // TC: O(n)
    // SC: O(1)
    public int SumOfMultiples(int n)
    {
        var sum = 0;
        for (var i = 1; i <= n; i++)
        {
            if (i % 3 == 0 || i % 5 == 0 || i % 7 == 0) sum += i;
        }
        return sum;
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