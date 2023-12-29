public class Q88_MergeSortedArrayTests {
    [Theory]
    [InlineData(new int[]{1,2,3,0,0,0}, 3, new int[]{2,5,6}, 3, new int[]{1,2,2,3,5,6})]
    [InlineData(new int[]{1}, 1, new int[]{}, 0, new int[]{1})]
    [InlineData(new int[]{0}, 0, new int[]{1}, 1, new int[]{1})]
    [InlineData(new int[]{1,0}, 1, new int[]{2}, 1, new int[]{1,2})]
    public void OfficialTestCases(int[] nums1, int m, int[] nums2, int n, int[] expected) {
        var sut = new Q88_MergeSortedArray();
        sut.Merge(nums1, m, nums2, n);
        Console.WriteLine(string.Join(',', nums1));
        Assert.True(nums1.SequenceEqual(expected));
    }
}

/*
Constraints:

nums1.length == m + n
nums2.length == n
0 <= m, n <= 200
1 <= m + n <= 200
-10^9 <= nums1[i], nums2[j] <= 10^9
*/

public class Q88_MergeSortedArray {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        if(n == 0) {
            return;
        } else if (m == 0) {
            Array.Copy(nums2, nums1, n);
            return;
        }

        Array.Copy(nums2, 0, nums1, m, n);
        Array.Sort(nums1);
    }
}