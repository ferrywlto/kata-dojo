class Q704_BinarySearch
{
    // TC: O(log n)
    // SC: O(1)
    public int Search(int[] nums, int target) 
    {
        if (nums.Length == 1) return nums[0] == target ? 0 : -1;

        int left = 0, right = nums.Length - 1;

        while(right-left > 1)
        {
            var middle = (right + left)/2;
            
            if (target == nums[middle]) return middle;
            if (target > nums[middle]) left = middle;
            else right = middle;
        }
        if (nums[left] == target) return left;
        if (nums[right] == target) return right;
        return -1; 
    }
}

class Q704_BinarySearchTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{5}, 5, 0],
        [new int[]{2,5}, 5, 1],
        [new int[]{-1,0,3,5,9,12}, 9, 4],
        [new int[]{-1,0,3,5,9,12}, 2, -1],
    ];
}

public class Q704_BinarySearchTests
{
    [Theory]
    [ClassData(typeof(Q704_BinarySearchTestData))]
    public void OfficialTestCases(int[] input, int target, int expected)
    {
        var sut = new Q704_BinarySearch();
        var actual = sut.Search(input, target);
        Assert.Equal(expected, actual);
    }
}