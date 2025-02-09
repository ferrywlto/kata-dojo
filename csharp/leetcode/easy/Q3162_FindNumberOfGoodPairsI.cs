public class Q3162_FindNumberOfGoodPairsI
{
    public int NumberOfPairs(int[] nums1, int[] nums2, int k)
    {
        return 0;
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