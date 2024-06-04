using System.Text;

class Q1071_GreatestCommonDivisorOfStrings
{
    // TC: O(n), length of str1+str2 for string.Join()
    // SC: O(n), length of str1+str2 to create temp string for compare but much smaller than original approach
    private int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
    public string GcdOfStrings2(string str1, string str2)
    {
        var gcd = GCD(str1.Length, str2.Length);
        var canFromStr1 = string.Join(string.Empty, Enumerable.Repeat(str1[..gcd], str1.Length / gcd)) == str1;
        var canFormStr2 = string.Join(string.Empty, Enumerable.Repeat(str1[..gcd], str2.Length / gcd)) == str2;
        return (canFormStr2 && canFromStr1) ? str1[..gcd] : string.Empty;
    }

    // TC: O(n^2) because of nested while loop brute force approach
    // SC: O(n), it have to keep creating substrings in loop
    public string GcdOfStrings(string str1, string str2)
    {
        var sb = new StringBuilder();
        // check if both strings repeat itself, if not then no need to do the rest
        if (str1.Length > 1)
        {
            sb.Append(str1 + str1);
            var idx1 = sb.ToString().IndexOf(str1, (str1.Length / 2) - 1);
            if (idx1 >= str1.Length) return "";
            sb.Clear();
        }
        if (str2.Length > 1)
        {
            sb.Append(str2 + str2);
            var idx2 = sb.ToString().IndexOf(str2, (str2.Length / 2) - 1);
            if (idx2 >= str2.Length) return "";
            sb.Clear();
        }
        // Determine which is longer, as the GCD must be smaller than or equal to the shorter length
        string shorter;
        string longer;
        if (str1.Length > str2.Length)
        {
            longer = str1;
            shorter = str2;
        }
        else
        {
            longer = str2;
            shorter = str1;
        }
        // Start from longest substring, check if it can form the longer one
        var len = shorter.Length;
        while (len > 0)
        {
            sb.Clear();
            if (longer.Length % len != 0 || shorter.Length % len != 0)
            {
                len--;
                continue;
            }
            var temp = shorter[..len];
            var currentIdx = 0;
            while (currentIdx + len <= longer.Length)
            {
                var firstIdx = longer.IndexOf(temp, currentIdx);
                if (currentIdx == firstIdx)
                {
                    currentIdx = firstIdx + len;
                    sb.Append(temp);
                }
                else break;
            }
            if (longer.Equals(sb.ToString())) return temp;
            len--;
        }
        return string.Empty;
    }
}
class Q1071_GreatestCommonDivisorOfStringsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["ABCABC", "ABC", "ABC"],
        ["ABABAB", "ABAB", "AB"],
        ["LEET", "CODE", ""],
        ["TAUXXTAUXXTAUXXTAUXXTAUXX", "TAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXX", "TAUXX"],
        ["AAAAAAAAA", "AAACCC", ""],
        ["AA", "A", "A"],
    ];
}
public class Q1071_GreatestCommonDivisorOfStringsTests
{
    [Theory]
    [ClassData(typeof(Q1071_GreatestCommonDivisorOfStringsTestData))]
    public void OfficialTestCases(string input1, string input2, string expected)
    {
        var sut = new Q1071_GreatestCommonDivisorOfStrings();
        var actual = sut.GcdOfStrings2(input1, input2);
        Assert.Equal(expected, actual);
    }
}