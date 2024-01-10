namespace dojo.leetcode;

public class Q35_SearchInsertPositionTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] { 1, 3, 5, 6 }, 5, 2],
        [new int[] { 1, 3, 5, 6 }, 2, 1],
        [new int[] { 1, 3, 5, 6 }, 7, 4],
        [new int[] { 2, 7, 8, 9, 10 }, 9, 3],
    ];
}

public class Q35_SearchInsertPositionTests
{
    [Theory]
    [ClassData(typeof(Q35_SearchInsertPositionTestData))]
    public void OfficialTestCases(int[] nums, int target, int expected)
    {
        var sut = new Q35_SearchInsertPosition();
        var actual = sut.SearchInsert(nums, target);
        Assert.Equal(expected, actual);
    }
}

/*
1 <= nums.length <= 104
104 <= nums[i] <= 104
nums contains distinct values sorted in ascending order.
-104 <= target <= 104
*/
public class Q35_SearchInsertPosition
{
    // Speed: 67ms (97.52%), Memory: 41,97MB (5.62%)
    public int SearchInsert(int[] nums, int target)
    {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0] >= target ? 0 : 1;
        if (target <= nums[0]) return 0;
        if (target > nums[^1]) return nums.Length;
        if (target == nums[^1]) return nums.Length - 1;

        ushort start = 0;
        ushort end = (ushort)(nums.Length - 1);
        ushort middle;
        while (start != end && end - start != 1)
        {
            middle = (ushort)Math.Ceiling((double)((end + start) / 2));

            if (target == nums[middle])
            {
                return middle;
            }
            else if (target > nums[middle])
            {
                // Introducing early termination by doing next element check does not improve performance
                // if (target == nums[middle + 1]) {
                //     return middle + 1;
                // }
                start = middle;
            }
            else
            {
                // if (target == nums[middle - 1]) {
                //     return middle - 1;
                // }
                end = middle;
            }
            // Console.WriteLine($"start: {start}, end: {end}, middle: {middle}");
        }
        return end;
    }
}
