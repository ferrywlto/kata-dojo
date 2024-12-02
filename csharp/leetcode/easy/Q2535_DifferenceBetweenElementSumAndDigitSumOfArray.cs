public class Q2535_DifferenceBetweenElementSumAndDigitSumOfArray
{
    // TC: O(n * d), n scale with length of nums, d scale with digits in each number 
    // SC: O(1), space used does not scale with input
    public int DifferenceOfSum(int[] nums)
    {
        var digitSum = 0;
        var elementSum = 0;
        foreach (var n in nums)
        {
            var temp = n;
            elementSum += temp;
            while (temp > 0)
            {
                digitSum += temp % 10;
                temp /= 10;
            }
        }
        return Math.Abs(digitSum - elementSum);
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,15,6,3}, 9],
        [new int[] {1,2,3,4}, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = DifferenceOfSum(input);
        Assert.Equal(expected, actual);
    }
}