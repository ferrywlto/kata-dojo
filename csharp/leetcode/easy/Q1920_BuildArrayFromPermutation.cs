class Q1920_BuildArrayFromPermutation
{
    // TC: O(n), where n is length of nums
    // SC: O(n), where n scale with length of nums
    public int[] BuildArray(int[] nums)
    {
        var ans = new int[nums.Length];
        for(var i=0; i<nums.Length; i++)
        {
            ans[i] = nums[nums[i]];
        }
        return ans;
    }
}
class Q1920_BuildArrayFromPermutationTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {0,2,1,5,3,4}, 
         new int[] {0,1,2,4,5,3}],
        [new int[] {5,0,1,2,3,4}, 
         new int[] {4,5,0,1,2,3}],
    ];
}
public class Q1920_BuildArrayFromPermutationTests
{
    [Theory]
    [ClassData(typeof(Q1920_BuildArrayFromPermutationTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q1920_BuildArrayFromPermutation();
        var actual = sut.BuildArray(input);
        Assert.Equal(expected, actual);
    }
}