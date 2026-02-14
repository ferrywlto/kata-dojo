public class Q3162_FindNumberOfGoodPairsI
{
    // TC: O(n * m), n scale with length of nums1, and m scale with length of nums2
    // SC: O(1), space used does not scale with input 
    public int NumberOfPairs(int[] nums1, int[] nums2, int k)
    {
        var result = 0;
        for (var i = 0; i < nums1.Length; i++)
        {
            for (var j = 0; j < nums2.Length; j++)
            {
                if (nums1[i] % (nums2[j] * k) == 0) result++;
            }
        }
        return result;
    }
    public static TheoryData<int[], int[], int, int> TestData => new()
    {
        {[1,3,4], [1,3,4], 1, 5},
        {[1,2,4,12], [2,4], 3, 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int k, int expected)
    {
        var actual = NumberOfPairs(input1, input2, k);
        Assert.Equal(expected, actual);
    }
}
