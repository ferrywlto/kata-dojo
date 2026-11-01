using System.Text;

public class Q4097_MinValueOfMergedIntegers
{
    // TC: O(n)
    // SC: O(1), it caps at 8 characters long
    public int MinMergedInteger(int[] nums)
    {
        var min = int.MaxValue;

        var sb = new StringBuilder();
        for (var i = 0; i < nums.Length; i += 2)
        {
            sb.Append(nums[i]).Append(nums[i + 1]);
            var num = int.Parse(sb.ToString());
            if (num < min) min = num;
            sb.Clear();
        }

        return min;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [23, 55, 42, 21], 2355 },
        { [34, 7, 11, 11], 347 },
        { [9, 20], 920 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinMergedInteger(input);
        Assert.Equal(expected, actual);
    }
}
