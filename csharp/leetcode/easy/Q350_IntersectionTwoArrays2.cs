
namespace dojo.leetcode;

public class Q350_IntersectionTwoArrays2
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        return [];
    }
}

public class Q350_IntersectionTwoArrays2TestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,2,2,1}, new int[]{2,2}, new int[] {2,2}],
        [new int[]{4,9,5}, new int[]{9,4,9,8,4}, new int[] {4,9}],
    ];
}

public class Q350_IntersectionTwoArrays2Tests
{
    [Theory]
    [ClassData(typeof(Q350_IntersectionTwoArrays2TestData))]
    public void OfficialTestCases(int[] input1, int[] input2, int[] expected)
    {
        var sut = new Q350_IntersectionTwoArrays2();
        var actual = sut.Intersect(input1, input2);
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}