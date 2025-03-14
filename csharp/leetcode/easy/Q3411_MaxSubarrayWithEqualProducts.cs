public class Q3411_MaxSubarrayWithEqualProducts(ITestOutputHelper ouptut)
{
    // TC: O(n^3)
    // SC: O(1), space used does not scale with input
    public int MaxLength(int[] nums)
    {
        for (var size = nums.Length - 1; size >= 1; size--)
        {
            ouptut.WriteLine("size: {0} -----", size);
            for (var i = 0; i < nums.Length - size; i++)
            {
                ouptut.WriteLine("nums[{0}]: {1}", i, nums[i]);
                if (Calulate(nums, i, i + size)) return size + 1;
            }
        }
        return 1;
    }
    private bool Calulate(int[] arr, int startIdx, int endIdx)
    {
        var gcd = GCD(arr[startIdx], arr[startIdx + 1]);
        var lcm = Math.Abs(arr[startIdx] * arr[startIdx + 1]) / gcd;
        var product = arr[startIdx] * arr[startIdx + 1];
        ouptut.WriteLine("inner i nums[{0}]: {1}", startIdx, arr[startIdx]);
        ouptut.WriteLine("inner i nums[{0}]: {1}, lcm: {2}, gcd: {3}, product: {4}", startIdx + 1, arr[startIdx + 1], lcm, gcd, product);
        for (var i = startIdx + 2; i <= endIdx; i++)
        {
            gcd = GCD(gcd, arr[i]);
            lcm = Math.Abs(lcm * arr[i]) / GCD(lcm, arr[i]);

            product *= arr[i];
            ouptut.WriteLine("inner i nums[{0}]: {1}, lcm: {2}, gcd: {3}, product: {4}", i, arr[i], lcm, gcd, product);
        }
        return product == gcd * lcm;
    }

    private int LCM(int a, int b)
    {
        return Math.Abs(a * b) / GCD(a, b);
    }
    private int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,1,2,1,1,1], 5},
        {[2,3,4,5,6], 3},
        {[1,2,3,1,4,5,1], 5},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxLength(input);
        Assert.Equal(expected, actual);
    }
}