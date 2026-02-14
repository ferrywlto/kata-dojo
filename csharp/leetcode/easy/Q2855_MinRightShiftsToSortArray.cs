public class Q2855_MinRightShiftsToSortArray
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int MinimumRightShifts(IList<int> nums)
    {
        if (nums.Count == 1) return 0;

        var firstDown = -1;
        var downCount = 0;
        for (var i = 1; i < nums.Count; i++)
        {
            if (nums[i] < nums[i - 1])
            {
                if (downCount == 0)
                {
                    firstDown = i;
                    downCount++;
                }
                else return -1;
            }
        }

        if (downCount == 0) return 0;
        // If the end is smaller than the start, it cannot be solved by right shift, at some point it will shows there is two down
        // If the list is sortable it must be 0 or only 1 down 
        if (nums[0] < nums[^1]) return -1;
        return nums.Count - firstDown;
    }
    public static TheoryData<IList<int>, int> TestData => new()
    {
        {new List<int>(){3,4,5,1,2}, 2},
        {new List<int>(){3,5,7,1,2,4}, -1},
        {new List<int>(){1,3,5}, 0},
        {new List<int>(){2,1,4}, -1},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(IList<int> input, int expected)
    {
        var actual = MinimumRightShifts(input);
        Assert.Equal(expected, actual);
    }
}
