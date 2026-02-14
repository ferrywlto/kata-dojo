public class Q3318_FindXSumOfAllKLongSubarraysI
{
    // TC: O(n^2), n scale with length of nums, for each result it iterates 5n times in XSum
    // SC: O(n+m), n sacle with the result size, m scale with unique numbers in each subarray
    private readonly Dictionary<int, int> frequency = new();
    private int sum = 0;
    public int[] FindXSum(int[] nums, int k, int x)
    {
        var result = new int[nums.Length - k + 1];

        //initialize
        for (var i = 0; i <= k - 1; i++)
        {
            if (frequency.TryGetValue(nums[i], out var val))
            {
                frequency[nums[i]] = ++val;
            }
            else
            {
                frequency.Add(nums[i], 1);
            }
            sum += nums[i];
        }

        if (frequency.Count >= x)
        {
            result[0] = frequency
                .OrderByDescending(p => p.Value)
                .ThenByDescending(p => p.Key)
                .Take(x)
                .Sum(p => p.Key * p.Value);
        }
        else result[0] = sum;

        for (var i = 1; i < result.Length; i++)
        {
            result[i] = XSum(nums, i, i + k - 1, x);
        }
        return result;
    }
    private int XSum(int[] input, int start, int end, int top)
    {
        sum -= input[start - 1];
        frequency[input[start - 1]]--;
        if (frequency[input[start - 1]] == 0)
        {
            frequency.Remove(input[start - 1]);
        }

        if (frequency.TryGetValue(input[end], out var val))
        {
            frequency[input[end]] = ++val;
        }
        else
        {
            frequency.Add(input[end], 1);
        }
        sum += input[end];

        if (frequency.Count < top) return sum;

        else return frequency
            .OrderByDescending(p => p.Value)
            .ThenByDescending(p => p.Key)
            .Take(top)
            .Sum(p => p.Key * p.Value);
    }
    public static TheoryData<int[], int, int, int[]> TestData => new()
    {
        {[1,1,2,2,3,4,2,3], 6, 2, [6,10,12]},
        {[3,8,7,8,7,5], 2, 2, [11,15,15,15,12]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int x, int[] expected)
    {
        var actual = FindXSum(input, k, x);
        Assert.Equal(expected, actual);
    }
}
