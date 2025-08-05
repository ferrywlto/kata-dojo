using System.Text;

public class Q2242_CountNumberOfDistinctIntegersAfterReverseOperations
{
    // TC: O(n), n scale with length of nums
    // SC: O(n) for storing the result
    public int CountDistinctIntegers(int[] nums)
    {
        var distinct = new HashSet<string>();
        var sb = new StringBuilder();
        var len = nums.Length;
        for (var i = 0; i < len; i++)
        {
            distinct.Add(nums[i].ToString());
            while (nums[i] > 0)
            {
                sb.Append(nums[i] % 10);
                nums[i] /= 10;
            }
            distinct.Add(int.Parse(sb.ToString()).ToString());
            sb.Clear();
        }
        return distinct.Count;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,13,10,12,31], 6},
        {[2,2,2], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountDistinctIntegers(input);
        Assert.Equal(expected, actual);
    }
}
