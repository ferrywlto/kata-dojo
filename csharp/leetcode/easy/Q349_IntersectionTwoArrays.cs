class Q349_IntersectionOfTwoArrays
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        var set3 = nums1.Intersect(nums2);
        return [.. set3];
    }

    // TC:O(n), SC:O(n)
    public int[] IntersectionSet(int[] nums1, int[] nums2)
    {
        var set1 = nums1.ToHashSet();
        var set2 = nums2.ToHashSet();
        var result = new List<int>();

        foreach (var i in set2)
        {
            if (set1.Contains(i)) result.Add(i);
        }

        return result.ToArray();
    }
}

class Q349_IntersectionOfTwoArraysTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,2,2,1}, new int[]{2,2}, new int[]{2}],
        [new int[]{4,9,5}, new int[]{9,4,9,8,4}, new int[]{9,4}],
        [new int[]{1,2}, new int[]{1,1}, new int[]{1}],
    ];
}

public class Q349_IntersectionOfTwoArraysTests
{
    [Theory]
    [ClassData(typeof(Q349_IntersectionOfTwoArraysTestData))]
    public void OfficialTestCases(int[] input1, int[] input2, int[] expected)
    {
        var sut = new Q349_IntersectionOfTwoArrays();
        var actual = sut.IntersectionSet(input1, input2);
        Assert.Equal(expected, actual);
    }
}
