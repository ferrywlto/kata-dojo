using System.Text;

public class Q2242_CountNumberOfDistinctIntegersAfterReverseOperations
{
    // TC: O(n), n scale with length of nums
    // SC: O(n) for storing the result
    public int CountDistinctIntegers(int[] nums)
    {
        var distinct = new HashSet<int>();
        var len = nums.Length;
        for (var i = 0; i < len; i++)
        {
            var n = nums[i];
            var reverse = 0;
            while (n > 0)
            {
                var digit = n % 10;

                reverse *= 10;
                reverse += digit;

                n /= 10;
            }
            distinct.Add(nums[i]);

            if (reverse != nums[i])
                distinct.Add(reverse);
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
