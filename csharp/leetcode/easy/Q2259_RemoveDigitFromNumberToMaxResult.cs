public class Q2259_RemoveDigitFromNumberToMaxResult
{
    // TC: O(n^2), n scale with length of number, then for each n compare n times for new number
    // SC: O(1), space used does not scale with input
    public string RemoveDigit(string number, char digit)
    {
        var max = string.Empty;

        for (var i = 0; i < number.Length; i++)
        {
            if (number[i] == digit)
            {
                var temp = number[..i] + number[(i + 1)..];

                if (string.Compare(temp, max) > 0) max = temp;
            }
        }
        return max;
    }
    public static List<object[]> TestData =>
    [
        ["123", '3', "12"],
        ["1231", '1', "231"],
        ["551", '5', "51"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, char digit, string expected)
    {
        var actual = RemoveDigit(input, digit);
        Assert.Equal(expected, actual);
    }
}