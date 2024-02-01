namespace dojo.leetcode;

public class Q349_IntersectionOfTwoArrays
{
        public int[] Intersection(int[] nums1, int[] nums2) {
        return [];
    }
}

public class Q349_IntersectionOfTwoArraysTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,2,2,1}, new int[]{2,2}, new int[]{1}],
        [new int[]{4,9,5}, new int[]{9,4,9,8,4}, new int[]{4,9}],
    ];
}

public class Q349_IntersectionOfTwoArraysTests
{
    [Theory]
    [ClassData(typeof(Q349_IntersectionOfTwoArraysTestData))]
    public void OfficialTestCases(int[] input1, int[] input2, int[] expected)
    {
        var sut = new Q349_IntersectionOfTwoArrays();
        var actual = sut.Intersection(input1, input2);
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}