public class Q2544_AlternatingDigitSum
{
    // TC: O(n), n scale with number of digits in n
    // SC: O(n), same as time
    public int AlternateDigitSum(int n)
    {
        var result = 0;
        var str = n.ToString();
        for (var i = 0; i < str.Length; i++)
        {
            if (i % 2 == 0) result += str[i] - '0';
            else result -= str[i] - '0';
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [521, 4],
        [111, 1],
        [886996, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = AlternateDigitSum(input);
        Assert.Equal(expected, actual);
    }
}