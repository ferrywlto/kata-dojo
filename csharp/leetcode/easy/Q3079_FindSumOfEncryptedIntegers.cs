public class Q3079_FindSumOfEncryptedIntegers
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int SumOfEncryptedInt(int[] nums)
    {
        var result = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            result += encrypt(nums[i]);
        }
        return result;
    }
    private int encrypt(int input)
    {
        var largestDigit = 0;
        var digitCount = 0;
        while (input > 0)
        {
            var d = input % 10;
            if (d > largestDigit) largestDigit = d;
            digitCount++;
            input /= 10;
        }
        var result = largestDigit;
        for (var i = 1; i < digitCount; i++)
        {
            result *= 10;
            result += largestDigit;
        }
        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3], 6},
        {[10,21,31], 66},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = SumOfEncryptedInt(input);
        Assert.Equal(expected, actual);
    }
}