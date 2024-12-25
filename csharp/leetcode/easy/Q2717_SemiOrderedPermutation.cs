public class Q2717_SemiOrderedPermutation
{
    // TC: O(n), n sacle with length of nums to iterate all items to find the idx of 1 and N
    // SC: O(1), space used does not scale with input
    public int SemiOrderedPermutation(int[] nums)
    {
        var idx1 = -1;
        var idxN = -1;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1) idx1 = i;
            else if (nums[i] == nums.Length) idxN = i;
        }

        var result = idx1 + nums.Length - idxN - 1;
        return (idx1 < idxN)
        ? result
        : result - 1;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[2,1,4,3], 2},
        {[2,4,1,3], 3},
        {[1,3,4,2,5], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = SemiOrderedPermutation(input);
        Assert.Equal(expected, actual);
    }
}