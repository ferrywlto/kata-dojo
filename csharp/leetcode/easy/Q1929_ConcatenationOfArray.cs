class Q1929_ConcatenationOfArray
{
    // TC: O(n), where n is length of nums
    // SC: O(n), where n scales with length of nums for storing the result
    public int[] GetConcatenation(int[] nums)
    {
        var result = new int[nums.Length * 2];
        Array.Copy(nums, result, nums.Length);
        Array.Copy(nums, 0, result, nums.Length, nums.Length);
        return result;
    }
}
class Q1929_ConcatenationOfArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,2,1}, new int[] {1,2,1,1,2,1}],
        [new int[]{1,3,2,1}, new int[] {1,3,2,1,1,3,2,1}],
    ];
}
public class Q1929_ConcatenationOfArrayTests
{
    [Theory]
    [ClassData(typeof(Q1929_ConcatenationOfArrayTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q1929_ConcatenationOfArray();
        var actual = sut.GetConcatenation(input);
        Assert.Equal(expected, actual);
    }
}