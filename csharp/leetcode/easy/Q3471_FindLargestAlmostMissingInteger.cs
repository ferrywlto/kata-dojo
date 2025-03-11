public class Q3471_FindLargestAlmostMissingInteger
{
    // TC: O(n * m), n scale with length of nums, m scale with unique numbers in nums
    // SC: O(m + k)
    public int LargestInteger(int[] nums, int k)
    {
        var existCounts = new int[51];
        var freq = new Dictionary<int, int>();
        var currentSet = new HashSet<int>();

        for (var x = 0; x <= 50; x++)
        {
            freq.Add(x, 0);
        }
        for (var i = 0; i < k; i++)
        {
            freq[nums[i]]++;
            currentSet.Add(nums[i]);
        }
        foreach (var n in currentSet) existCounts[n]++;

        for (var j = 1; j <= nums.Length - k; j++)
        {
            freq[nums[j - 1]]--;
            if (freq[nums[j - 1]] == 0)
            {
                currentSet.Remove(nums[j - 1]);
            }

            freq[nums[j + k - 1]]++;
            currentSet.Add(nums[j + k - 1]);

            foreach (var n in currentSet) existCounts[n]++;
        }

        var largest = -1;
        for (var y = 0; y < existCounts.Length; y++)
        {
            if (existCounts[y] == 1 && y > largest)
            {
                largest = y;
            }
        }
        return largest;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[3,9,2,1,7], 3, 7},
        {[3,9,7,2,1,7], 4, 3},
        {[3,9,7,2,1,7], 6, 9},
        {[3,9,7,2,1,7], 1, 9},
        {[11,0,11,0,0,3,3,8], 4, 8},
        {[0,0], 1, -1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = LargestInteger(input, k);
        Assert.Equal(expected, actual);
    }
}