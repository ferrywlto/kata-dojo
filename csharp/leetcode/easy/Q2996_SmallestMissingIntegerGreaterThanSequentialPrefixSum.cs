public class Q2996_SmallestMissingIntegerGreaterThanSequentialPrefixSum
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique numbers in nums
    public int MissingInteger(int[] nums)
    {
        var prefixSum = nums[0];
        var set = new HashSet<int> { nums[0] };

        var prefixEnded = false;
        for (var i = 1; i < nums.Length; i++)
        {
            set.Add(nums[i]);
            if (prefixEnded) continue;

            if (nums[i] == nums[i - 1] + 1) prefixSum += nums[i];
            else prefixEnded = true;
        }

        if (!set.Contains(prefixSum)) return prefixSum;

        var target = prefixSum + 1;
        while (set.Contains(target)) target++;
        return target;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[3,4,5,1,12,14,13], 15},
        {[1,4,3], 2},
        {[19,47,6,8,9,20], 21},
        {[38], 39},
        {[14,9,6,9,7,9,10,4,9,9,4,4], 15},
        {[37,1,2,9,5,8,5,2,9,4], 38},
        {[46,8,2,4,1,4,10,2,4,10,2,5,7,3,1], 47},

        {[1,2,3,2,5], 6},
        {[18,19,20,21,22,23,24,25,26,27,28,9], 253},
        {[29,30,31,32,33,34,35,36,37], 297},
        {[1,2,3,9,2,10,8,3,10,2], 6},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MissingInteger(input);
        Assert.Equal(expected, actual);
    }
}