public class Q3688_BitwiseOrOfEvenNumbersInArray
{
    // TC: O(n), n scale with nums.Length
    // SC: O(1), space used does not scale with input
    public int EvenNumberBitwiseORs(int[] nums)
    {
        var result = 0;
        foreach (var num in nums)
        {
            if (num % 2 == 0)
            {
                result |= num;
            }
        }
        return result;
    }

    public static TheoryData<int[], int> TestData =>
        new()
        {
            { [1,2,3,4,5,6], 6 },
            { [7,9,11], 0 },
            { [1,8,16], 24 }
        };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int expected)
    {
        var result = EvenNumberBitwiseORs(nums);
        Assert.Equal(expected, result);
    }
}
