public class Q2044_CountNumOfMaxBitwiseOrSubsets
{
    // TC: O(2^n), used brute force for small constraints
    // SC: O(1), space used does not scale with input
    public int CountMaxOrSubsets(int[] nums)
    {
        var max = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            max |= nums[i];
        }

        var result = 0; // the whole array must be one of them

        // Loop through all possible subsets using bit manipulation
        var n = nums.Length;
        for (var i = 0; i < (1 << n); i++)
        {
            var temp = 0;
            for (var j = 0; j < n; j++)
            {
                if ((i & (1 << j)) != 0)
                {
                    temp |= nums[j];
                }
            }
            if (temp == max) result++;
        }
        return result;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        {[3,1], 2},
        {[2,2,2], 7},
        {[3,2,1,5], 6},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountMaxOrSubsets(input);
        Assert.Equal(expected, actual);
    }
}
