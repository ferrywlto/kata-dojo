public class Q3354_MakeArrayElementsEqualToZero
{
    // TC: O(n + m), n sacle with length of nums, m sacle with number of zeros in nums
    // SC: O(m)
    public int CountValidSelections(int[] nums)
    {
        var sumL = 0;
        var sumR = 0;
        var leftSum = new Dictionary<int, int>();
        var rightSum = new Dictionary<int, int>();
        var back = nums.Length - 1;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0) sumL += nums[i];
            else leftSum.Add(i, sumL);

            if (nums[back - i] != 0) sumR += nums[back - i];
            else rightSum.Add(back - i, sumR);
        }

        var result = 0;
        foreach (var p in leftSum)
        {
            if (p.Value == rightSum[p.Key]) result += 2;
            else if (Math.Abs(p.Value - rightSum[p.Key]) == 1) result++;
        }
        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,0,2,0,3], 2},
        {[1,1,1,0,3], 2},
        {[2,3,4,0,4,1,0], 0},
        {[16,13,10,0,0,0,10,6,7,8,7], 3}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountValidSelections(input);
        Assert.Equal(expected, actual);
    }
}
