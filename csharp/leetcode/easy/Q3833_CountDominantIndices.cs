// TC: O(n), n scale with length of nums
// SC: O(1), space used does not scale with input
public class Q3833_CountDominantIndices
{
    public int DominantIndices(int[] nums)
    {
        var dominantCount = 0;
        var sum = 0;
        for (var i = nums.Length - 1; i >= 1; i--)
        {
            sum += nums[i];
            var avg = sum / (double)(nums.Length - i);
            if (nums[i - 1] > avg)
                dominantCount++;
        }
        return dominantCount;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[5,4,3], 2},
        {[4,1,2], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = DominantIndices(input);
        Assert.Equal(expected, actual);
    }
}
