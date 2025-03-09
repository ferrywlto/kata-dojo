using System.Text;

public class Q3461_CheckIfDigitsAreEqualInStringAfterOperationsI
{
    // TC: O(n^2), n scale with length of s, iterates whole string until length is 2
    // SC: O(n), most space used in the first iteration, n + n - 1
    public bool HasSameDigits(string s)
    {
        var sb1 = new StringBuilder(s);
        var sb2 = new StringBuilder();
        while (sb1.Length > 2)
        {
            sb2.Clear();
            for (var i = 0; i < sb1.Length - 1; i++)
            {
                var digit1 = sb1[i] - '0';
                var digit2 = sb1[i + 1] - '0';
                var ch = (char)(((digit1 + digit2) % 10) + '0');
                sb2.Append(ch);
            }
            sb1.Clear();
            sb1.Append(sb2);
        }
        return sb1[0] == sb1[1];
    }
    public static TheoryData<string, bool> TestData => new()
    {
        {"3902", true},
        {"34789", false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = HasSameDigits(input);
        Assert.Equal(expected, actual);
    }
}