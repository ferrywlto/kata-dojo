public class Q3712_SumElementsWithFrequencyDivisibleByK
{
    public int SumDivisibleByK(int[] nums, int k)
    {
        var freq = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (freq.TryGetValue(num, out var count))
            {
                freq[num] = count + 1;
            }
            else
            {
                freq.Add(num, 1);
            }
        }

        var sum = 0;
        foreach (var (num, count) in freq)
        {
            if (count % k == 0)
            {
                sum += num * count;
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
