
class Q976_LargestPerimeterTriangle
{
    // TC: O(n log n), n is length of nums, dominated by Array.Sort, which is O(n log n)
    // SC: O(1), as Array.Sort modify array in place
    public int LargestPerimeter(int[] nums)
    {
        Array.Sort(nums);
        for (var i = nums.Length - 1; i >= 2; i--)
        {
            if (CanFormTriangle(nums[i], nums[i - 1], nums[i - 2]))
            {
                return nums[i] + nums[i - 1] + nums[i - 2];
            }
        }
        return 0;
    }

    private bool CanFormTriangle(int length1, int length2, int length3)
    {
        return length1 + length2 > length3
        && length1 + length3 > length2
        && length2 + length3 > length1;
    }
}

class Q976_LargestPerimeterTriangleTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {2,1,2}, 5],
        [new int[] {1,2,1,10}, 0],
    ];
}

public class Q976_LargestPerimeterTriangleTests
{
    [Theory]
    [ClassData(typeof(Q976_LargestPerimeterTriangleTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q976_LargestPerimeterTriangle();
        var actual = sut.LargestPerimeter(input);
        Assert.Equal(expected, actual);
    }
}
