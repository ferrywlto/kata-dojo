
public class Q2656_MaxSumWithExactlyKElements
{
    // TC: O(n + k), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int MaximizeSum(int[] nums, int k)
    {
        var max = int.MinValue;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > max) max = nums[i];
        }
        var sum = 0;
        for (var j = 0; j < k; j++)
        {
            sum += max;
            max++;
        }
        return sum;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {new int[] {1,2,3,4,5}, 3, 18},
        {new int[] {5,5,5}, 2, 11},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = MaximizeSum(input, k);
        Assert.Equal(expected, actual);
    }
}
