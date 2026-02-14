public class Q3697_ComputeDecimalRepresentation
{
    // TC: O(log n), n scale with the size of the number
    // SC: O(d), d is the number of digits in n
    public int[] DecimalRepresentation(int n)
    {
        var result = new List<int>();
        var radix = 1;
        while (n > 0)
        {
            var digit = n % 10;
            if (digit != 0)
            {
                result.Insert(0, digit * radix);
            }
            n /= 10;
            radix *= 10;
        }
        return result.ToArray();
    }
    public static TheoryData<int, int[]> TestData => new TheoryData<int, int[]>
    {
      {537, [500,30,7]},
      {102, [100,2]},
      {6, [6]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[] expected)
    {
        var result = DecimalRepresentation(n);
        Assert.Equal(expected, result);
    }
}
