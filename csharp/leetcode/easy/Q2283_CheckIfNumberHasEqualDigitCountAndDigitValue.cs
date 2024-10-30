public class Q2283_CheckIfNumberHasEqualDigitCountAndDigitValue
{
    // TC: O(n), n scale with length of num, iterate once for getting the frequency, another iteration check if the digit index equals frequency
    // SC: O(m), m scale with unique digits in num 
    public bool DigitCount(string num)
    {
        var frequency = num
            .GroupBy(c => c)
            .ToDictionary(g => g.Key - '0', g => g.Count());

        for (var i = 0; i < num.Length; i++)
        {
            var v = num[i] - '0';
            if (frequency.TryGetValue(i, out var value))
            {
                if (v != value) return false;
            }
            else if (v != 0) return false;
        }
        return true;
    }
    public static List<object[]> TestData =>
    [
        ["1210", true],
        ["030", false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = DigitCount(input);
        Assert.Equal(expected, actual);
    }
}