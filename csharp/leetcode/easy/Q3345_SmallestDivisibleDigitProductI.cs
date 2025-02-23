public class Q3345_SmallestDivisibleDigitProductI
{
    // TC: O(n log 10), n scale inversely, the smaller the n, the more operation required
    // SC: O(1), space used does not scale with input 
    public int SmallestNumber(int n, int t)
    {
        for (var i = n; i <= 100; i++)
        {
            var product = DigitProduct(i);
            if (product % t == 0) return i;
        }
        return 0;
    }
    private int DigitProduct(int input)
    {
        var product = input % 10;
        input /= 10;
        while (input > 0)
        {
            product *= input % 10;
            input /= 10;
        }
        return product;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {10, 5, 10},
        {15, 3, 16},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int t, int expected)
    {
        var actual = SmallestNumber(input, t);
        Assert.Equal(expected, actual);
    }
}