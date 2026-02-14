public class Q3779_MinNumOpsToHaveDistinctElements
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique numbers in nums
    public int MinOperations(int[] nums)
    {
        var set = new HashSet<int>();
        var lastDupIdx = -1;

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            var key = nums[i];
            if (!set.Add(key))
            {
                lastDupIdx = i;
                break;
            }
        }

        if (lastDupIdx == -1) return 0;

        return (lastDupIdx / 3) + 1;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        {[3,8,3,6,5,8], 1},
        {[2,2], 1},
        {[4,3,5,1,2], 0},
        {[87,15,26,32,32,18], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}
