using System.Numerics;

public class Q4039_SumOfDecodedNumbers(ITestOutputHelper output)
{
    /* The solution can be faster with the following approach to avoid binary search and power of ten array lookup.
    int totalwidth = repeatly / 10
    long mult = 1;
    for (int i = 0; i < totalwidth - width; i++)
    {
        mult *= 10;
    }
    // left part
    long x = d / mult;
    // right part
    long y = d - x * mult;
     */
    private const long mod = 1_000_000_000L + 7;

    static readonly long[] PowersOfTen =
    [
        1L,
        10L,
        100L,
        1_000L,
        10_000L,
        100_000L,
        1_000_000L,
        10_000_000L,
        100_000_000L,
        1_000_000_000L,
        10_000_000_000L,
        100_000_000_000L,
        1_000_000_000_000L,
        10_000_000_000_000L,
        100_000_000_000_000L,
        1_000_000_000_000_000L,
        // Constraints to only 10^15
        // 10_000_000_000_000_000L,
        // 100_000_000_000_000_000L,
        // 1_000_000_000_000_000_000L
    ];

    private int GetDigitCount(long input)
    {
        int idx = Array.BinarySearch(PowersOfTen, input);
        // Binary search result, negative means not found. Refer to doc for details
        int digitCount = idx >= 0 ? idx + 1 : ~idx;
        return digitCount;
    }

    private (long left, long right) Spilt(long input, long anchor)
    {
        var idx = GetDigitCount(input) - anchor;

        return (input / PowersOfTen[idx], input % PowersOfTen[idx]);
    }

    // The trick here is to use BigInteger.ModPow to calculate x^y mod z without creating the impossible large number first.
    private long Decode(long x, long y) => (long)(BigInteger.ModPow(x, y, mod));

    // TC: O(n log n), n scale with length of nums and log n is from binary search.
    // SC: O(1)
    public int SumDecoded(long[] nums)
    {
        long result = 0L;

        foreach (var num in nums)
        {
            var width = num % 10;
            var dimension = num / 10;
            (long left, long right) = Spilt(dimension, width);
            var decoded = Decode(left, right);
            // No need to do modulus as decoded is cap at 10^9+7, the length of nums is 10^5 which 10^9+7 * 10^5 approximately 10^14, which is still far less than long.MaxValue.
            result += decoded;
        }

        return (int)(result % mod);
    }

    public static TheoryData<long[], int> TestData => new()
    {
        { [231], 8 },
        { [2522, 2101], 1649 },
        { [2301], 73741817 },
        { [59412], 44723187 },
    };

    [Theory]
    [InlineData(987654321L, 1, 9L, 87654321L)]
    [InlineData(987654321L, 2, 98L, 7654321L)]
    [InlineData(987654321L, 3, 987L, 654321L)]
    [InlineData(123123123123L, 1, 1L, 23123123123L)]
    [InlineData(123123123123L, 2, 12L, 3123123123L)]
    [InlineData(123123123123L, 3, 123L, 123123123L)]
    public void TestY(long input, int width, long left, long right)
    {
        (long actualLeft, long actualRight) = Spilt(input, width);

        output.WriteLine($"input: {input}, width: {width}, left: {actualLeft}, right: {actualRight}");
        Assert.Equal(left, actualLeft);
        Assert.Equal(right, actualRight);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(long[] input, int expected)
    {
        var actual = SumDecoded(input);
        Assert.Equal(expected, actual);
    }
}
