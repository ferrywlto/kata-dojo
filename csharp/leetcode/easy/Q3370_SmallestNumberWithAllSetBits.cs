public class Q3370_SmallestNumberWithAllSetBits
{
    // TC: O(1), worst case there will only be 10 operations as n <= 1000, 2^10 = 1024
    // SC: O(1), space used does not scale with input
    public int SmallestNumber(int n)
    {
        var x = 1;
        while (x <= 1000)
        {
            if (x >= n) return x;
            x <<= 1;
            x++;
        }
        return x;
    }
    public static TheoryData<int, int> TestData => new()
    {
        {5, 7},
        {10, 15},
        {3, 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = SmallestNumber(input);
        Assert.Equal(expected, actual);
    }
}