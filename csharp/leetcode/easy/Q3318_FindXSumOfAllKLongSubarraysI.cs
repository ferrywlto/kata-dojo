public class Q3318_FindXSumOfAllKLongSubarraysI
{
    // TC: O(n^2), n scale with length of nums, for each result it iterates 5n times in XSum
    // SC: O(n+m), n sacle with the result size, m scale with unique numbers in each subarray 
    public int[] FindXSum(int[] nums, int k, int x)
    {
        var result = new int[nums.Length - k + 1];
        for (var i = 0; i < result.Length; i++)
        {
            result[i] = XSum(nums, i, i + k - 1, x);
        }
        return result;
    }
    private int XSum(int[] input, int start, int end, int top)
    {
        var dict = new SortedDictionary<int, int>();
        var sum = 0;
        for (var i = start; i <= end; i++)
        {
            if (dict.TryGetValue(input[i], out var val))
            {
                dict[input[i]] = ++val;
            }
            else
            {
                dict.Add(input[i], 1);
            }
            sum += input[i];
        }

        if (dict.Count < top) return sum;

        sum = dict
            .OrderByDescending(p => p.Value)
            .ThenByDescending(p => p.Key)
            .Take(top)
            .Sum(p => p.Key * p.Value);

        return sum;
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