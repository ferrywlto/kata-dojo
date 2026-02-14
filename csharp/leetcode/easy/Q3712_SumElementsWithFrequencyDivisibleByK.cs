public class Q3712_SumElementsWithFrequencyDivisibleByK
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), freq array size is fixed
    public int SumDivisibleByK(int[] nums, int k)
    {
        var freq = new int[101];
        foreach (var num in nums)
        {
            freq[num]++;
        }

        var sum = 0;
        for (var i = 1; i < freq.Length; i++)
        {
            if (freq[i] % k == 0)
            {
                sum += i * freq[i];
            }
        }
        return sum;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        { [1,2,2,3,3,3,3,4], 2, 16 },
        { [1,2,3,4,5], 2, 0 },
        { [4,4,4,1,2,3], 3, 12 },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int k, int expected)
    {
        var result = SumDivisibleByK(nums, k);
        Assert.Equal(expected, result);
    }
}
