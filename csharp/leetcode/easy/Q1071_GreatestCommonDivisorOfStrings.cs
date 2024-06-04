using System.Text;

class Q1071_GreatestCommonDivisorOfStrings
{
    public string GcdOfStrings(string str1, string str2)
    {
        var sb = new StringBuilder();
        if (str1.Length > 1)
        {
            sb.Append(str1 + str1);
            var idx1 = sb.ToString().IndexOf(str1, (str1.Length / 2) - 1);
            if (idx1 >= str1.Length) return "";
            Console.WriteLine($"str1 repeat test: {sb}, idx1: {idx1}");
            sb.Clear();
        }
        if (str2.Length > 1)
        {
            sb.Append(str2 + str2);
            var idx2 = sb.ToString().IndexOf(str2, (str2.Length / 2) - 1);
            if (idx2 >= str2.Length) return "";
            Console.WriteLine($"str2 repeat test: {sb}, idx2: {idx2}");
            sb.Clear();
        }
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

        Console.WriteLine($"longer: {longer}, shorte: {shorter}");
        var len = shorter.Length;
        while (len > 0)
        {
            sb.Clear();
            if (longer.Length % len != 0 || shorter.Length % len != 0)
            {
                len--;
                continue;
            }
            Console.WriteLine($"len: {len} is divisible longer.Length: {longer.Length}");

            var temp = shorter[..len];
            var currentIdx = 0;
            while (currentIdx + len <= longer.Length)
            {
                var firstIdx = longer.IndexOf(temp, currentIdx);
                Console.WriteLine($"len: {len}, currentIdx: {currentIdx}, sum: {currentIdx + len} is shorter than longer.Length: {longer.Length}, firstIdx after find: {firstIdx}");
                if (currentIdx == firstIdx)
                {
                    currentIdx = firstIdx + len;
                    sb.Append(temp);
                }
                else break;
            }
            Console.WriteLine($"longer: {longer}, sb: {sb}");
            if (longer.Equals(sb.ToString()))
            {
                return temp;
            }
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
        var actual = sut.GcdOfStrings(input1, input2);
        Assert.Equal(expected, actual);
    }
}