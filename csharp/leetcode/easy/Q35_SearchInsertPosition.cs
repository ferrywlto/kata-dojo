public class Q35_SearchInsertPositionTests {
    [Theory]
    [InlineData(new int[] { 1, 3, 5, 6 }, 5, 2)]
    [InlineData(new int[] { 1, 3, 5, 6 }, 2, 1)]
    [InlineData(new int[] { 1, 3, 5, 6 }, 7, 4)]
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
public class Q35_SearchInsertPosition {
    public int SearchInsert(int[] nums, int target) {
        return 0;
    } 
}