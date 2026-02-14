class Q1608_SpecialArrayWithXElementsGreaterThanOrEqualX
{
    // TC: O(n log n), where n is the length of nums and dominated by Array.Sort();
    // SC: O(1), space used is fixed
    public int SpecialArray(int[] nums)
    {
        Array.Sort(nums);
        // 1. it doesn't need to check x = 0, as 0 elements >= 0 is not possible as the array contains only positive integers 
        // 2. x must be less than or equal to nums.Length, it cannot have 8 elements larger than or equals to 8 in a 7 elements array 
        if (nums[0] >= nums.Length) return nums.Length;

        for (var i = 0; i < nums.Length - 1; i++)
        {
            var normalized = i + 1;
            var larger = nums[^normalized];
            var smaller = nums[^(normalized + 1)];
            if (normalized > smaller && normalized <= larger) return normalized;
        }
        return -1;
    }
}
class Q1608_SpecialArrayWithXElementsGreaterThanOrEqualXTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {2}, 1],
        [new int[] {2,1}, -1],
        [new int[] {0,0,0,0,0,9}, 1],
        [new int[] {7,6,9,8,7,9}, 6],
        [new int[] {3,5}, 2],
        [new int[] {0,0}, -1],
        [new int[] {0,4,3,0,4}, 3],
    ];
}
public class Q1608_SpecialArrayWithXElementsGreaterThanOrEqualXTests
{
    [Theory]
    [ClassData(typeof(Q1608_SpecialArrayWithXElementsGreaterThanOrEqualXTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1608_SpecialArrayWithXElementsGreaterThanOrEqualX();
        var actual = sut.SpecialArray(input);
        Assert.Equal(expected, actual);
    }
}
