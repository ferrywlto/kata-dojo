class Q1920_BuildArrayFromPermutation
{
    // TC: O(n), where n is length of nums
    // SC: O(1), where n scale with length of nums
    // The O(1) version need to understand encoding two values into one
    public int[] BuildArray(int[] nums)
    {
        int n = nums.Length;

        // Encode the new values
        for (int i = 0; i < n; i++)
        {
            nums[i] = nums[i] + nums[nums[i]] % n * n;
        }

        // Decode the new values
        for (int i = 0; i < n; i++)
        {
            nums[i] = nums[i] / n;
        }
        return nums;
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
        [new int[] {3,2,1,0},
         new int[] {0,1,2,3}],
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
