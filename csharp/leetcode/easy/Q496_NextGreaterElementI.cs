
namespace dojo.leetcode;

public class Q496_NextGreaterElementI
{
    // Constraints:
    // 1 <= nums1.length <= nums2.length <= 1000
    // 0 <= nums1[i], nums2[i] <= 104
    // All integers in nums1 and nums2 are unique.
    // All the integers of nums1 also appear in nums2.

    // TC: O(n^2)
    // SC: O(n)
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        var dict = new Dictionary<int, int>();
        
        for(var i = 0; i<nums2.Length; i++)
        {
            foreach(var p in dict)
            {
                if (nums2[i] > p.Key && p.Value == -1)
                {
                    dict[p.Key] = nums2[i];
                }
            }
            dict.Add(nums2[i], -1);
        }

        var result = new List<int>();
        for(var j = 0; j<nums1.Length; j++)
        {
            result.Add(dict[nums1[j]]);
        }
        return result.ToArray();
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