public class Q3065_MinOperationsToExceedThresoldValueI
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int MinOperations(int[] nums, int k)
    {
        var result = 0;
        foreach (var n in nums)
        {
            if (n < k) result++;
        }
        return result;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[2,11,10,1,3], 10, 3},
        {[1,1,2,4,9], 1, 0},
        {[1,1,2,4,9], 9, 4},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = MinOperations(input, k);
        Assert.Equal(expected, actual);
    }
}