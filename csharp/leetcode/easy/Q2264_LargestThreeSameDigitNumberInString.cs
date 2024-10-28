public class Q2264_LargestThreeSameDigitNumberInString
{
    // TC: O(n), n scale with length of num
    // SC: O(1), space used does not scale with input
    public string LargestGoodInteger(string num)
    {
        var maxDigit = '/';
        var result = string.Empty;
        for (var i = 0; i < num.Length - 2; i++)
        {
            if (num[i] == num[i + 1] && num[i] == num[i + 2])
            {
                if (num[i] > maxDigit)
                {
                    maxDigit = num[i];
                    result = num[i..(i + 3)];
                }
            }
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        ["6777133339", "777"],
        ["67771333999", "999"],
        ["2300019", "000"],
        ["42352338", ""],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = LargestGoodInteger(input);
        Assert.Equal(expected, actual);
    }
}