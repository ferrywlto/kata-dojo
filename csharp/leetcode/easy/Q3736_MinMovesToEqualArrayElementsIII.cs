public class Q3736_MinMovesToEqualArrayElementsIII
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used is constant
    public int MinMoves(int[] nums)
    {
        var max = int.MinValue;
        var sum = 0;
        foreach (var num in nums)
        {
            sum += num;
            if (num > max)
            {
                max = num;
            }
        }
        var expected = max * nums.Length;
        return expected - sum;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[2,1,3], 3},
        {[4,4,5], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int expected)
    {
        var result = MinMoves(nums);
        Assert.Equal(expected, result);
    }
}
