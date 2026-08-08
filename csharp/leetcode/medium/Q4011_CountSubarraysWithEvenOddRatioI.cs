public class Q4011_CountSubarraysWithEvenOddRatioI
{
    // TC: O(n^2), needs to test all subarrays
    // SC: O(n) for using stack to improve speed.
    public int CountRatioSubarrays(int[] nums, int a, int b)
    {
        var len = nums.Length;
        Span<int> span = stackalloc int[len];

        for (var i = 0; i < len; i++)
            span[i] = nums[i] % 2;

        double ratio = (double)a / b;

        var result = 0;
        for (var i = 0; i < len; i++)
        {
            var oddCount = 0;  // y
            var evenCount = 0; // x
            for (var j = i; j < len; j++)
            {
                if (span[j] == 0)
                    evenCount++;
                else
                    oddCount++;

                if (oddCount > 0 && (double)evenCount / oddCount <= ratio)
                    result++;
            }
        }
        return result;
    }

    public static TheoryData<int[], int, int, int> TestData => new()
    {
        {[1,2,1,2], 3, 2, 7},
        {[2,2,1], 2, 1, 3},
        {[2,2,2], 1, 1, 0},
        {[304,979,652,115], 182, 922, 2},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int a, int b, int expected)
    {
        var actual = CountRatioSubarrays(input, a, b);
        Assert.Equal(expected, actual);
    }
}
