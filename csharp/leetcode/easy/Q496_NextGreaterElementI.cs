
namespace dojo.leetcode;

public class Q496_NextGreaterElementI
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        return [];
    }
}

public class Q496_NextGreaterElementITestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {4,1,2}, new int[] {1,3,4,2}, new int[] {-1,3,-1}],
        [new int[] {2,4}, new int[] {1,2,3,4}, new int[] {3,-1}],
    ];
}

public class Q496_NextGreaterElementITests
{
    [Theory]
    [ClassData(typeof(Q496_NextGreaterElementITestData))]
    public void OfficialTestCases(int[] nums1, int[] nums2, int[] expected)
    {
        var sut = new Q496_NextGreaterElementI();
        var actual = sut.NextGreaterElement(nums1, nums2);
        Assert.Equal(expected, actual);
    }
}