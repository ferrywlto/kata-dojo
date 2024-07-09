class Q1403_MinSubsequenceInNonIncreasingOrder
{
    // TC: O(n log n), due to Array.Sort();
    // SC: O(n), for holding the results
    public IList<int> MinSubsequence(int[] nums)
    {
        Array.Sort(nums);
        var total = nums.Sum();
        var leftSum = total;
        var rightSum = 0;
        var result = new List<int>();
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            result.Add(nums[i]);
            rightSum += nums[i];
            leftSum -= nums[i];
            if (rightSum > leftSum) return result;
        }
        return result;
    }
}
class Q1403_MinSubsequenceInNonIncreasingOrderTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] { 4, 3, 10, 9, 8 }, new List<int> { 10, 9 }],
        [new int[] { 4, 4, 7, 6, 7 }, new List<int> { 7, 7, 6 }],
    ];
}
public class Q1403_MinSubsequenceInNonIncreasingOrderTests
{
    [Theory]
    [ClassData(typeof(Q1403_MinSubsequenceInNonIncreasingOrderTestData))]
    public void OfficialTestCases(int[] input, List<int> expected)
    {
        var sut = new Q1403_MinSubsequenceInNonIncreasingOrder();
        var actual = sut.MinSubsequence(input);
        Assert.Equal(expected, actual);
    }
}