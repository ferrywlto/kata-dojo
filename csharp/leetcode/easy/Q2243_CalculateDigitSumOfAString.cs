using System.Text;

public class Q2243_CalculateDigitSumOfAString
{
    // TC: O(n log n), the log n comes from each iteration length reduce a factor of k, times each character is iterated in Round()
    // SC: O(n), n scale with length of s due to String Builder 
    public string DigitSum(string s, int k)
    {
        if (s.Length <= k) return s;

        var sb = new StringBuilder(s);
        while (sb.Length > k)
        {
            var roundResult = Round(sb.ToString(), k);
            sb.Clear();
            sb.Append(roundResult);
        }
        return sb.ToString();
    }
    public string Round(string input, int k)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < input.Length; i += k)
        {
            var group = i + k < input.Length
                ? input[i..(i + k)]
                : input[i..];

            var sum = 0;
            foreach (var c in group) sum += c - '0';

            sb.Append(sum);
        }

        return sb.ToString();
    }
    public static List<object[]> TestData =>
    [
        ["11111222223", 3, "135"],
        ["00000000", 3, "000"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, string expected)
    {
        var actual = DigitSum(input, k);
        Assert.Equal(expected, actual);
    }
}
