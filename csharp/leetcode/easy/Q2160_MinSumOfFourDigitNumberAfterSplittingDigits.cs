public class Q2160_MinSumOfFourDigitNumberAfterSplittingDigits
{
    // TC: O(1), The question constraint implies that the input is always 4 digits, thus the time used in Array.Sort() is constant.
    // SC: O(1), The space used is constant, limit to 4 digits due to question constraints.
    public int MinimumSum(int num)
    {
        var arr = new int[4];
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = num % 10;
            num /= 10;
        }
        Array.Sort(arr);
        return arr[0] * 10 + arr[2] + arr[1] * 10 + arr[3];
    }
    public static List<object[]> TestData =>
    [
        [2932, 52],
        [4009, 13],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = MinimumSum(input);
        Assert.Equal(expected, actual);
    }
}